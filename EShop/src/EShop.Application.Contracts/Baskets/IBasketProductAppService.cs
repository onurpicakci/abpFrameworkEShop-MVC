using System;
using System.Threading.Tasks;
using EShop.Products;
using JetBrains.Annotations;

namespace EShop.Baskets;

public interface IBasketProductAppService 
{
    [ItemNotNull]
    Task<ProductDto> GetAsync(Guid productId);
}

