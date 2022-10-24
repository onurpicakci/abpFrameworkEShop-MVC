using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace EShop.Baskets;

public class BasketAppService :
    CrudAppService<
        Basket,
        BasketDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateBasketDto>,
    IBasketAppService
{
    public BasketAppService(IRepository<Basket,Guid> repository)
        : base(repository)
    {

    }
}

