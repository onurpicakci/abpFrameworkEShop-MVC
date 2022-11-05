using System;
using System.Threading.Tasks;
using EShop.Products;
using Microsoft.Extensions.Logging;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.ObjectMapping;

namespace EShop.Baskets;

	public class BasketProductService : IBasketProductService, ITransientDependency
	{

    private readonly IDistributedCache<ProductDto, Guid> _cache;
    private readonly ILogger<BasketProductService> _logger;
    private readonly IObjectMapper _mapper;
 

    public BasketProductService()
		{
		}

    public Task<ProductDto> GetAsync(Guid productId)
    {
        throw new NotImplementedException();
    }
}

