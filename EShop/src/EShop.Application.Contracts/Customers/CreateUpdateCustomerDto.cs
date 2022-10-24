using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.Customers;

public class CreateUpdateCustomerDto
{
    [Required]
    public Guid BasketId { get; set; }
}

