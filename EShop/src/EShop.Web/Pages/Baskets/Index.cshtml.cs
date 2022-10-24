using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EShop.Web.Pages.Baskets;

public class IndexModel : AbpPageModel
{
    public void OnGet()
    {

    }

    public IActionResult OnPostAsync()
    {
        if (!CurrentUser.IsAuthenticated)
        {
            Logger.LogInformation("Redirecting to Login");
            return Challenge();
        }

        return RedirectToPage("Payment");
    }
}
