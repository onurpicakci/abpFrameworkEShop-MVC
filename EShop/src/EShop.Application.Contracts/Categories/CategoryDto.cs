using System;
using System.Collections.Generic;
using EShop.Products;
using Volo.Abp.Application.Dtos;

namespace EShop.Categories;

public class CategoryDto : AuditedEntityDto<Guid>
{
    public string CategoryName { get; set; }

    public List<ProductDto> Products { get; set; }
}

