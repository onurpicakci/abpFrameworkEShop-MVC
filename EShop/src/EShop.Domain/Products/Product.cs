using System;
using Volo.Abp.Domain.Entities.Auditing;
using EShop.Categories;

namespace EShop.Products
{
    public class Product : AuditedAggregateRoot<Guid>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public int StockCount { get; set; }

        public string ProductDescription { get; set; }

        public string ImageName { get; set; }

        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }

        
        
    }
}

