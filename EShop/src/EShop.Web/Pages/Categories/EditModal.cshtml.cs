using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShop.Web.Pages.Categories
{
    public class EditModalModel : EShopPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        private readonly ICategoryAppService _categoryAppService;

        [BindProperty]
        public CreateUpdateCategoryDto Category { get; set; }

        public EditModalModel(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }


        public async Task OnGetAsync()
        {
            var categoryDto = await _categoryAppService.GetAsync(Id);
            Category = ObjectMapper.Map<CategoryDto, CreateUpdateCategoryDto>(categoryDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _categoryAppService.UpdateAsync(Id, Category);

            return NoContent();
        }
    }
}
