using System;
using System.ComponentModel.DataAnnotations;
using EShop.Categories;

namespace EShop.Products;

public class CreateUpdateProductDto
{
    [Required]
    public string Code { get; set; }

    [Required]
    [StringLength(128)]
    public string Name { get; set; }

    [Required]
    public float Price { get; set; }

    [Required]
    public int StockCount { get; set; }

    [Required]
    public string ProductDescription { get; set; }

    [Required]
    public Guid CategoryId { get; set; }



}

