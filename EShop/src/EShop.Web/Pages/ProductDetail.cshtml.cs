using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EShop.Web.Pages.Products;

public class ProductDetailModel : AbpPageModel
{

    public ProductDto Product { get; private set; }
    public bool IsPurschased { get; private set; }

    private readonly IPublicProductAppService _productAppService;

    public ProductDetailModel(IPublicProductAppService productAppService)
    {
        _productAppService = productAppService;
    }


    public async Task OnGet(Guid id)
    {
        Product = await _productAppService.GetAsync(id);
    }
}
