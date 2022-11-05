using System;
using Volo.Abp.Content;

namespace EShop.Files;

public class BlobUploadDto
{
    public IRemoteStreamContent File { get; set; }

    public string Name { get; set; }
}

public class BlobInfoDto
{

    public string Name { get; set; }
}

