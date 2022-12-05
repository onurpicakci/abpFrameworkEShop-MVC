using System;
using Volo.Abp.Application.Dtos;

namespace EShop.Products;

public class MySearchFilterDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
