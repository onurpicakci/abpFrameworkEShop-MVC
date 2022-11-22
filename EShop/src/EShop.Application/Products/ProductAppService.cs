using System;
using System.Collections.Generic;
using System.Linq;
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
        MySearchFilterDto,
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

    public override async Task<PagedResultDto<ProductDto>> GetListAsync(MySearchFilterDto input)
    {
        var queryable = await base.Repository.GetQueryableAsync();
        var query = queryable.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), Product => Product.Name.ToLower()
            .Contains(input.Filter.ToLower()));

        var count = await AsyncExecuter.CountAsync(query);
        var products = await AsyncExecuter.ToListAsync(query);

        var result = ObjectMapper.Map<List<Product>, List<ProductDto>>(products);

        return new PagedResultDto<ProductDto> { Items = result, TotalCount = count };


    }
}

