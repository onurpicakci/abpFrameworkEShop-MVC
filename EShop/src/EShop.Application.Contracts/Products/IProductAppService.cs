using System;
using System.Threading.Tasks;
using EShop.Files;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace EShop.Products;

public interface IProductAppService
    : ICrudAppService<
        ProductDto,
        Guid,
        MySearchFilterDto,
        CreateUpdateProductDto>
{

}
