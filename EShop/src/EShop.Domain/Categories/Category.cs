using System;
using System.Collections.Generic;
using EShop.Products;
using Volo.Abp.Domain.Entities.Auditing;

namespace EShop.Categories;

    public class Category : AuditedAggregateRoot<Guid>
    {
        public string CategoryName { get; set; }
        
    }


