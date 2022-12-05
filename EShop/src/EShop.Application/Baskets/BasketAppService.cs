using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Products;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;
using static EShop.Permissions.EShopPermissions;

namespace EShop.Baskets;

public class BasketAppService : ApplicationService, IBasketAppService
{

    private readonly IBasketProductService _basketProductService;
    private readonly IRepository<Basket, Guid> _basketRepository;
    private readonly IRepository<BasketItem, Guid> _basketItemRepository;

    public BasketAppService(IBasketProductService basketProductAppService, IRepository<Basket, Guid> basketRepository, IRepository<BasketItem, Guid> basketItemRepository)
    {
        _basketRepository = basketRepository;
        _basketProductService = basketProductAppService;
        _basketItemRepository = basketItemRepository;
    }

    public async Task<BasketDto> AddProductAsync(AddProductDto input)
    {

        var basketItems =  (await _basketRepository.WithDetailsAsync(x => x.BasketItems)).ToList();
        var basketItem = basketItems.FirstOrDefault(x => x.BasketItems.Any(y => y.ProductId == input.ProductId));

        var product = await _basketProductService.GetAsync(input.ProductId);

        if (basketItem == null)
        {
            basketItem = (new Basket(Guid.NewGuid()) { BasketItems = new List<BasketItem>() { new BasketItem(input.ProductId) } });
            await _basketRepository.InsertAsync(basketItem);
            
        }
        if (basketItem.GetProductCount(input.ProductId) >= product.StockCount)
        {
            throw new UserFriendlyException("There is not enough product in stock, sorry");
        }
 
        basketItem.AddProduct(input.ProductId);

        return await GetBasketDtoAsync(basketItem);

    }

    public async Task<BasketDto> GetAsync(Guid? id)
    {
        if (CurrentUser.IsAuthenticated)
        {
            var userBasket = await _basketRepository.GetAsync(CurrentUser.GetId());
            var idUserBasket = await _basketRepository.GetAsync(id.Value);

            userBasket.Merge(idUserBasket);
            await _basketRepository.UpdateAsync(userBasket);

            userBasket.Clear();
            await _basketRepository.UpdateAsync(idUserBasket);

            return await GetBasketDtoAsync(userBasket);
        }

        return await GetBasketDtoAsync(await _basketRepository.GetAsync(CurrentUser.GetId()));
    }

    public async Task<BasketDto> RemoveProductAsync(RemoveProductDto input)
    {
        var basketItems = (await _basketRepository.WithDetailsAsync(x => x.BasketItems)).ToList();
        var basketItem = basketItems.FirstOrDefault(x => x.BasketItems.Any(y => y.ProductId == input.ProductId));

  
        if (basketItem == null)
        {
            basketItem = (new Basket(Guid.NewGuid()) { BasketItems = new List<BasketItem>() { new BasketItem(input.ProductId) } });
            await _basketRepository.DeleteAsync(basketItem);
        }

        basketItem.RemoveProduct(basketItem.Id, input.ProductCount);
        
        await _basketRepository.DeleteAsync(basketItem);

        return await GetBasketDtoAsync(basketItem);
    }

    private async Task<BasketDto>GetBasketDtoAsync(Basket basket)
    {
        var products = new Dictionary<Guid, ProductDto>();
        var basketDto = new BasketDto();
        var basketChanged = false;

        foreach (var basketItem in basket.BasketItems)
        {
            var productDto = products.GetOrDefault(basketItem.ProductId);

            if (productDto == null)
            {
                productDto = await _basketProductService.GetAsync(basketItem.ProductId);
                products[productDto.Id] = productDto;
            }

            if (basketItem.ProductCount > productDto.StockCount)
            {
                basket.RemoveProduct(basketItem.ProductId, basketItem.ProductCount - productDto.StockCount);
                basketChanged = true;
            }

            basketDto.BasketItems.Add(new BasketItemDto
            {
                ProductId = basketItem.ProductId,
                ProductCount = basketItem.ProductCount,
                ProductName = productDto.Name,
                TotalPrice = productDto.Price * basketItem.ProductCount,

            });
        }

        basketDto.TotalPrice = basketDto.BasketItems.Sum(x => x.TotalPrice);

        if (basketChanged)
        {
            await _basketRepository.UpdateAsync(basket);
        }

        return basketDto;
    }
}

