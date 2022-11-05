using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EShop.Categories;
using EShop.Files;
using EShop.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EShop.Web.Pages.Products;

public class CreateModel : EShopPageModel
{
    [BindProperty]
    public ProductCreateViewModel Product { get; set; }

    public CreateUpdateCategoryDto Categories { get; set; }

    public List<SelectListItem> CategoryList { get; set; }

    private readonly IFileAppService _fileAppService;

    private readonly IProductAppService _productAppService;

    private readonly ICategoryAppService _categoryAppService;

    public CreateModel(IProductAppService productAppService, ICategoryAppService categoryAppService, IFileAppService fileAppService)
    {
        _productAppService = productAppService;
        _categoryAppService = categoryAppService;
        _fileAppService = fileAppService;

    }

    public async Task OnGetAsync()
    {
        Product = new ProductCreateViewModel();
        Categories = new CreateUpdateCategoryDto();
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

    [HttpPost]
    public async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<ProductCreateViewModel, CreateUpdateProductDto>(Product);
        return new OkObjectResult(await _productAppService.CreateAsync(dto));
    }



    [AutoMap(typeof(CreateUpdateProductDto), ReverseMap = true)]
    public class ProductCreateViewModel
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
        [DisplayName("Image Name")]
        public string ImageName { get; set; }

        [Required]
        [SelectItems(nameof(CategoryList))]
        [DisplayName("Category")]
        public Guid CategoryId { get; set; }
    }
}

