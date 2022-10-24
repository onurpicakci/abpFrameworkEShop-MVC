using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EShop.Baskets;

public interface IBasketAppService
    : ICrudAppService<
        BasketDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateBasketDto>
{

}

