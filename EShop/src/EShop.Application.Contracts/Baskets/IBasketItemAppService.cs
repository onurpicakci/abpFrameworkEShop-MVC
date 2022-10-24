using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EShop.Baskets;

public interface IBasketItemAppService
    :   ICrudAppService<
        BasketItemDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateBasketItemDto>
{

}

