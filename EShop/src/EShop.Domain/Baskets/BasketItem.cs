using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace EShop.Baskets
{
    public class BasketItem : AuditedAggregateRoot<Guid>
    {
        public Guid ProductId { get; set; }

        public Guid BasketId { get; set; }

        public int ProductCount { get; set; }

        private BasketItem()
        {

        }

        public BasketItem(Guid productId, int productCount = 1)
        {
            ProductId = productId;
            ProductCount = productCount;
        }

    }
}

