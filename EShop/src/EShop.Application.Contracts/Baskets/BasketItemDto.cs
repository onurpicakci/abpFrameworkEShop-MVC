using System;
using Volo.Abp.Application.Dtos;

namespace EShop.Baskets;

public class BasketItemDto : AuditedEntityDto<Guid>
{
    public Guid ProductId { get; set; }

    public int ProductCount { get; set; }

    public float TotalPrice { get; set; }

    public string ImageName { get; set; }

    public string ProductName { get; set; }
}
