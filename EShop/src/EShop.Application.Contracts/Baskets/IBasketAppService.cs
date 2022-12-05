using System;
using System.Threading.Tasks;
using EShop.Products;
using JetBrains.Annotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EShop.Baskets;

public interface IBasketAppService : IApplicationService
{
    Task<BasketDto> GetAsync(Guid? id);
    Task<BasketDto> AddProductAsync(AddProductDto input);
    Task<BasketDto> RemoveProductAsync(RemoveProductDto input);



}
