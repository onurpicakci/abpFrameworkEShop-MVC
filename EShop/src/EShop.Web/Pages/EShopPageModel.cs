﻿using EShop.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EShop.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class EShopPageModel : AbpPageModel
{
    protected EShopPageModel()
    {
        LocalizationResourceType = typeof(EShopResource);
    }
}
