using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace EShop.Customers
{
    public class Customer : AuditedAggregateRoot<Guid>
    {
        public Guid BasketId { get; set; }

    }
}

