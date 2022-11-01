using System;
using System.Threading.Tasks;
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
    private readonly IBlobContainer<ProductImageBlobContainer> _blobContainer;

    public ProductAppService(IRepository<Product, Guid> repository, IBlobContainer<ProductImageBlobContainer> blobContainer)
        : base(repository)
    {
        _blobContainer = blobContainer;

        GetPolicyName = EShopPermissions.Products.Default;
        GetListPolicyName = EShopPermissions.Products.Default;
        CreatePolicyName = EShopPermissions.Products.Create;
        UpdatePolicyName = EShopPermissions.Products.Edit;
        DeletePolicyName = EShopPermissions.Products.Delete;
    }

    public async Task<ProductDto> UploadImageAsync(Guid id, RemoteStreamContent file)
    {
        var product = await Repository.GetAsync(id);

        await _blobContainer.SaveAsync(product.Id.ToString(), file.GetStream());

        return MapToGetOutputDto(product);
    }
}

