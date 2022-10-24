using System;
using Volo.Abp.Application.Dtos;

namespace EShop.Customers;

public class CustomerDto : AuditedEntityDto<Guid>
{
    public Guid BasketId { get; set; }
}

