using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.Files;

public class GetBlobRequestDto
{
    [Required]
    public string Name { get; set; }
}

