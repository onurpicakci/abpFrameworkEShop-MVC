using System;
using EShop.Products;
using JetBrains.Annotations;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace EShop.Baskets;

public interface IBasketProductService
{
    [ItemNotNull]
    Task<ProductDto> GetAsync(Guid id);

    Task<ListResultDto<BasketDto>> GetListAsync();
}

