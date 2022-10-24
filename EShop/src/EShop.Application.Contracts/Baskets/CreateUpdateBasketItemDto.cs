using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.Baskets;

public class CreateUpdateBasketItemDto
{
    [Required]
    public Guid ProductId { get; set; }

    [Required]
    public Guid BasketId { get; set; }

    [Required]
    public int ProductCount { get; set; }
}

