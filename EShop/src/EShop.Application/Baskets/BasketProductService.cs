using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EShop.Products;
using Microsoft.Extensions.Logging;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace EShop.Baskets;

	public class BasketProductService : ApplicationService, IBasketProductService
	{

    private readonly IRepository<Product, Guid> _basketProductRepository;
    private readonly IRepository<Basket, Guid> _basketRepository;
    private readonly IRepository<BasketItem, Guid> _basketItemRepository;

    public BasketProductService(IRepository<Product, Guid> basketProductRepository,  IRepository<Basket, Guid> basketRepository, IRepository<BasketItem, Guid> basketItemRepository)
	{
        _basketProductRepository = basketProductRepository;
        _basketRepository = basketRepository;
        _basketItemRepository = basketItemRepository;
	}

    public async Task<ProductDto> GetAsync(Guid id)
    {
        var product = await _basketProductRepository.GetAsync(id);
        return ObjectMapper.Map<Product, ProductDto>(product);
    }

    public async Task<ListResultDto<BasketItemDto>> GetLisAsync()
    {
        return new ListResultDto<BasketItemDto>(
           ObjectMapper.Map<List<BasketItem>, List<BasketItemDto>>(
               await _basketItemRepository.GetListAsync()));
    }

    public async Task<ListResultDto<BasketDto>> GetListAsync()
    {
        return new ListResultDto<BasketDto>(
            ObjectMapper.Map<List<Basket>, List<BasketDto>>(
                await _basketRepository.GetListAsync()));
    }
}

