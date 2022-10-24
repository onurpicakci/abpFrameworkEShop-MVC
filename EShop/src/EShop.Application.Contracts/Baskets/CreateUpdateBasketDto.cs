using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EShop.Baskets;

public class CreateUpdateBasketDto
{
    [Required]
    public Guid CustomerId { get; set; }

    [Required]
    public List<BasketItemDto> BasketItems { get; set; }
}

