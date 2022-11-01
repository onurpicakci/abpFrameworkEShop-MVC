using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Content;

namespace EShop.Files;

public class SaveBlobInputDto
{
    public byte[] Content { get; set; }

    [Required]
    public string Name { get; set; }
}

