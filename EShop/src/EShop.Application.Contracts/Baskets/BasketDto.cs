using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace EShop.Baskets;

public class BasketDto : AuditedEntityDto<Guid>
{
    public float TotalPrice { get; set; }
    public List<BasketItemDto> BasketItems { get; set; }

    public BasketDto()
    {
        BasketItems = new List<BasketItemDto>();
    }
}
