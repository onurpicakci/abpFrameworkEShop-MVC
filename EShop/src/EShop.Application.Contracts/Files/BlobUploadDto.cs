using System;
using Volo.Abp.Content;

namespace EShop.Files;

public class BlobDto
{
    public byte[] Content { get; set; }

    public string Name { get; set; }
}

