using System;
using Volo.Abp.Application.Dtos;

namespace EShop.Baskets;

public class BasketItemDto : AuditedEntityDto<Guid>
{
    public Guid ProductId { get; set; }

    public Guid BasketId { get; set; }

    public int ProductCount { get; set; }
}

