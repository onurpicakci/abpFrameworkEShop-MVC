using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace EShop.Products;

public interface IProductAppService
    : ICrudAppService<
        ProductDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateProductDto>
{
    Task<ProductDto> UploadImageAsync(Guid id, RemoteStreamContent file);
}

