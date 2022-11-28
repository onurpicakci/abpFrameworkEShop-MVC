using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace EShop.Baskets;

public class BasketItemAppService :
    CrudAppService<
        BasketItem,
        BasketItemDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateBasketItemDto>,
    IBasketItemAppService

{
    public BasketItemAppService(IRepository<BasketItem,Guid > repository)
        : base(repository)
    {
    }
}

