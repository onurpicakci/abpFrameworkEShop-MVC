using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EShop.Products;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace EShop.Files;

public interface IFileAppService : IApplicationService
{

    Task<BlobInfoDto> UploadImageAsync(BlobUploadDto input);
    Task<RemoteStreamContent> GetImageAsync(string fileName);
}

