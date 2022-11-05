using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EShop.Products;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace EShop.Baskets;

public class BasketAppService : ApplicationService, IBasketAppService
{

    private readonly IBasketRepository _basketRepository;
    private readonly IBasketProductService _basketProductService;

    public BasketAppService(IBasketRepository basketRepository, IBasketProductService basketProductAppService)
    {
        _basketRepository = basketRepository;
        _basketProductService = basketProductAppService;
    }

    public async Task<BasketDto> AddProductAsync(AddProductDto input)
    {
        Guid userId = CurrentUser.GetId();

        var basket = await _basketRepository.GetAsync(userId);
        var product = await _basketProductService.GetAsync(input.ProductId);

        if (basket.GetProductCount(product.Id) >= product.StockCount)
        {
            throw new UserFriendlyException("There is not enough product in stock, sorry :(");
        }

        basket.AddProduct(product.Id);

        return await GetBasketDtoAsync(basket);
    }

    public async Task<BasketDto> GetAsync(Guid? id)
    {
        if (CurrentUser.IsAuthenticated)
        {
            var userBasket = await _basketRepository.GetAsync(CurrentUser.GetId());
            var idUserBasket = await _basketRepository.GetAsync(id.Value);

            userBasket.Merge(idUserBasket);

            return await GetBasketDtoAsync(userBasket);
        }

        return await GetBasketDtoAsync(await _basketRepository.GetAsync(CurrentUser.GetId()));
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
                basketChanged = true;
            }

            basketDto.BasketItems.Add(new BasketItemDto
            {
                ProductId = basketItem.ProductId,
                BasketId =  basketItem.Id,
                ProductCount = basketItem.ProductCount,
                ProductCode = productDto.Code,

            });
        }

        return basketDto;
    }
}

