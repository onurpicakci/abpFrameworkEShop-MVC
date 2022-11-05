using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Content;

namespace EShop.Files;

public class SaveBlobInputDto
{
    public IRemoteStreamContent Content { get; set; }

    [Required]
    public string ImageName { get; set; }
}

