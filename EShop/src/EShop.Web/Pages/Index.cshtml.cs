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

    private readonly IProductAppService _productAppService;
    private readonly IPublicProductAppService _publicproductAppService;
    private readonly ICategoryAppService _categoryAppService;


    public IndexModel(IPublicProductAppService publicproductAppService, ICategoryAppService categoryAppService, IProductAppService productAppService)
    {
        _publicproductAppService = publicproductAppService;
        _categoryAppService = categoryAppService;
        _productAppService = productAppService;
    }


    public async Task OnGet()
    {
        try
        {
            Products = (await _publicproductAppService.GetListAsync()).Items;
        }
        catch (Exception ex)
        {
            Products = new ReadOnlyCollection<ProductDto>(new List<ProductDto>());
            HasRemoteServiceError = true;
            Console.WriteLine(ex);
        }
        
    }


}
