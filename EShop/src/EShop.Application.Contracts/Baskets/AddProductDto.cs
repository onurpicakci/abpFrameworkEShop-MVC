using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.Baskets;

public class AddProductDto
{
    public Guid ProductId { get; set; }

    [Range(1, int.MaxValue)]
    public int ProductCount { get; set; }
}

