using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using EShop.Categories;
using EShop.Products;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using static EShop.Permissions.EShopPermissions;

namespace EShop.Web.Pages;

public class IndexModel : AbpPageModel
{

    public IReadOnlyList<ProductDto> Products { get; set; }
    public bool HasRemoteServiceError { get; set; } = false;

    private readonly IPublicProductAppService _productAppService;
    private readonly ICategoryAppService _categoryAppService;


    public IndexModel(IPublicProductAppService productAppService, ICategoryAppService categoryAppService)
    {
        _productAppService = productAppService;
        _categoryAppService = categoryAppService;
    }


    public async Task OnGet()
    {
        try
        {
            Products = (await _productAppService.GetListAsync()).Items;
        }
        catch (Exception ex)
        {
            Products = new ReadOnlyCollection<ProductDto>(new List<ProductDto>());
            HasRemoteServiceError = true;
            Console.WriteLine(ex);
        }
    }


}
