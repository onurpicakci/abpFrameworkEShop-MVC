using System;
using EShop.Products;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EShop.Categories;

public class CreateUpdateCategoryDto
{
    [Required]
    [StringLength(256)]
    [Display(Name = "Category Name")]
    public string CategoryName { get; set; }

}

