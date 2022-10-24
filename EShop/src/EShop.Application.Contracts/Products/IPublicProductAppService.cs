using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EShop.Products;

public interface IPublicProductAppService : IApplicationService
{
    Task<ListResultDto<ProductDto>> GetListAsync();
    Task<ProductDto> GetAsync(Guid id);
}

