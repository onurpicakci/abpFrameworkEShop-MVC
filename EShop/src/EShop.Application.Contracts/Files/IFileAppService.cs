using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace EShop.Files;

public interface IFileAppService : IApplicationService
{

    Task SaveBlobAsync(SaveBlobInputDto input);
    Task<BlobDto> GetBlobAsync(GetBlobRequestDto input);

}

