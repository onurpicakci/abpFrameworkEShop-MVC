using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EShop.Categories;
using EShop.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using static EShop.Web.Pages.Products.CreateModel;

namespace EShop.Web.Pages.Products;

public class EditModel : EShopPageModel
{

    [BindProperty]
    public ProductEditViewModel Product { get; set; }

    public List<SelectListItem> CategoryList { get; set; }

    private readonly IProductAppService _productAppService;

    private readonly ICategoryAppService _categoryAppService;

    public EditModel(IProductAppService productAppService, ICategoryAppService categoryAppService)
    {
        _productAppService = productAppService;
        _categoryAppService = categoryAppService;
    }

    public async Task OnGetAsync(Guid id)
    {
        var productDto = await _productAppService.GetAsync(id);
        Product = ObjectMapper.Map<ProductDto, ProductEditViewModel>(productDto);

        var newList = await _categoryAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto
        {
            MaxResultCount = 15,
            SkipCount = 0
        });

        CategoryList = newList.Items.Select(x => new SelectListItem
        {
            Value = x.Id.ToString(),
            Text = x.CategoryName
        }).ToList();
    }

    
    public async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<ProductEditViewModel, CreateUpdateProductDto>(Product);
        await _productAppService.UpdateAsync(Product.Id, dto);
        return NoContent();


    }

    [AutoMap(typeof(CreateUpdateProductDto), ReverseMap = true)]
    [AutoMap(typeof(ProductDto))]
    public class ProductEditViewModel
    {
        [Required]
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

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
        [DisplayName("Image Name")]
        public string ImageName { get; set; }

        [Required]
        [SelectItems(nameof(CategoryList))]
        [DisplayName("Category")]
        public Guid CategoryId { get; set; }
    }
}


