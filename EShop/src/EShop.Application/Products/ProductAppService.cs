using System;
using System.Threading.Tasks;
using EShop.Files;
using EShop.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.Content;
using Volo.Abp.Domain.Repositories;

namespace EShop.Products;

public class ProductAppService
    : CrudAppService<
        Product,
        ProductDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateProductDto>,
    IProductAppService
{

    public ProductAppService(IRepository<Product, Guid> repository)
        :base(repository)
       
    {

        GetPolicyName = EShopPermissions.Products.Default;
        GetListPolicyName = EShopPermissions.Products.Default;
        CreatePolicyName = EShopPermissions.Products.Create;
        UpdatePolicyName = EShopPermissions.Products.Edit;
        DeletePolicyName = EShopPermissions.Products.Delete;
    }

}

