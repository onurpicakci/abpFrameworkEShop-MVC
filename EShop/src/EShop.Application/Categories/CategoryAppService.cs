using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EShop.Customers;
using EShop.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace EShop.Categories;

public class CategoryAppService
    : CrudAppService<
        Category,
        CategoryDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateCategoryDto>,
    ICategoryAppService
{

    public CategoryAppService(IRepository<Category, Guid> repository)
        :base(repository)
    {
        GetPolicyName = EShopPermissions.Categories.Default;
        GetListPolicyName = EShopPermissions.Categories.Default;
        CreatePolicyName = EShopPermissions.Categories.Create;
        UpdatePolicyName = EShopPermissions.Categories.Edit;
    }

    
}

