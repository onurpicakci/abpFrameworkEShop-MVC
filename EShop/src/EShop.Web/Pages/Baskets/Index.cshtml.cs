using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using EShop.Baskets;
using EShop.Categories;
using EShop.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EShop.Web.Pages.Baskets;

public class IndexModel : AbpPageModel
{

    public IReadOnlyList<ProductDto> Products { get; set; }
    public IReadOnlyList<BasketDto> Baskets { get; set; }
    public IReadOnlyList<BasketItemDto> BasketItems { get; set; }

    public bool HasRemoteServiceError { get; set; } = false;

    private readonly IProductAppService _productAppService;
    private readonly IPublicProductAppService _publicproductAppService;
    private readonly ICategoryAppService _categoryAppService;
    private readonly IBasketProductService _basketProductService;

    public IndexModel(IPublicProductAppService publicproductAppService, ICategoryAppService categoryAppService, IProductAppService productAppService, IBasketProductService basketProductService)
    {
        _publicproductAppService = publicproductAppService;
        _categoryAppService = categoryAppService;
        _productAppService = productAppService;
        _basketProductService = basketProductService;
    }
    public async Task OnGet()
    {
        try
        {
            Products = (await _publicproductAppService.GetListAsync()).Items;
            Baskets = (await _basketProductService.GetListAsync()).Items;
            BasketItems = (await _basketProductService.GetLisAsync()).Items;
        }
        catch (Exception ex)
        {
            Products = new ReadOnlyCollection<ProductDto>(new List<ProductDto>());
            Baskets = new ReadOnlyCollection<BasketDto>(new List<BasketDto>());
            HasRemoteServiceError = true;
            Console.WriteLine(ex);
        }
    }


}