using System;
using EShop.Products;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace EShop.Baskets;

public interface IBasketProductService
{
    [ItemNotNull]
    Task<ProductDto> GetAsync(Guid id);
}

