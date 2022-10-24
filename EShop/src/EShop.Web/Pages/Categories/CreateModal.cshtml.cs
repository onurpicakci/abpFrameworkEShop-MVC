using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShop.Web.Pages.Categories
{
    public class CreateModalModel : EShopPageModel
    {
        [BindProperty]
        public CreateUpdateCategoryDto Category { get; set; }

        private readonly ICategoryAppService _categoryAppService;

        public CreateModalModel(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        public void OnGet()
        {
            Category = new CreateUpdateCategoryDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _categoryAppService.CreateAsync(Category);
            return NoContent();
        }

    }
}
