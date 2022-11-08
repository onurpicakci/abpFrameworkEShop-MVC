using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.Baskets;

public class RemoveProductDto
{
    public Guid ProductId { get; set; }

    
    public int? ProductCount { get; set; }
}

