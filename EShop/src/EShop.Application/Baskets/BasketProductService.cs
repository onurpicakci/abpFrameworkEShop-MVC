using System;
using System.Threading.Tasks;
using EShop.Products;
using Microsoft.Extensions.Logging;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace EShop.Baskets;

	public class BasketProductService : ApplicationService, IBasketProductService
	{

    private readonly IRepository<Product, Guid> _basketProductRepository;
    public BasketProductService(IRepository<Product, Guid> basketProductRepository)
	{
        _basketProductRepository = basketProductRepository;
	}

    public async Task<ProductDto> GetAsync(Guid id)
    {
        var product = await _basketProductRepository.GetAsync(id);
        return ObjectMapper.Map<Product, ProductDto>(product);

    }
}

