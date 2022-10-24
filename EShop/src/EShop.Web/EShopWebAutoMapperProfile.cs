using AutoMapper;
using EShop.Categories;
using EShop.Products;

namespace EShop.Web;

public class EShopWebAutoMapperProfile : Profile
{
    public EShopWebAutoMapperProfile()
    {
        CreateMap<ProductDto, CreateUpdateProductDto>();
        CreateMap<CategoryDto, CreateUpdateCategoryDto>();
    }
}
