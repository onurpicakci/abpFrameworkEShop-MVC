using System;
using EShop.Products;
using System.Threading.Tasks;
using Volo.Abp.Content;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.BlobStoring;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;

namespace EShop.Files;

public class FileAppService : EShopAppService ,IFileAppService
{

    private readonly IBlobContainer<ProductImageBlobContainer> _blobContainer;

    public FileAppService(IBlobContainer<ProductImageBlobContainer> blobContainer)
    {
        _blobContainer = blobContainer;
    }

    public async Task<RemoteStreamContent> GetImageAsync(string fileName)
    {
        var stream = await _blobContainer.GetAsync(fileName);

        return new RemoteStreamContent(stream, fileName, "image/*");
    }

    public async Task<BlobInfoDto> UploadImageAsync(BlobUploadDto input)
    {
        await _blobContainer.SaveAsync(input.Name, input.File.GetStream(), overrideExisting: true);

        return new BlobInfoDto
        {
            Name = input.Name
        };
    }
}


