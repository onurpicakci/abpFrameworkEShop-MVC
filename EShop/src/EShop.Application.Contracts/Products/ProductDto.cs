using System;
using EShop.Categories;
using Volo.Abp.Application.Dtos;

namespace EShop.Products;

public class ProductDto : AuditedEntityDto<Guid>
{
    public string Code { get; set; }

    public string Name { get; set; }

    public float Price { get; set; }

    public int StockCount { get; set; }

    public string ProductDescription { get; set; }

    public Guid CategoryId { get; set; }


}

