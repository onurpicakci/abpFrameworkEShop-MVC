using AutoMapper;
using EShop.Baskets;
using EShop.Categories;
using EShop.Customers;
using EShop.Products;

namespace EShop;

public class EShopApplicationAutoMapperProfile : Profile
{
    public EShopApplicationAutoMapperProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<Customer, CustomerDto>();
        CreateMap<Category, CategoryDto>();
        CreateMap<Basket, BasketDto>();
        CreateMap<BasketItem, BasketItemDto>();

        CreateMap<CreateUpdateBasketDto, Basket>();
        CreateMap<CreateUpdateBasketItemDto, BasketItem>();
        CreateMap<CreateUpdateCategoryDto, Category>();
        CreateMap<CreateUpdateCustomerDto, Customer>();
        CreateMap<CreateUpdateProductDto, Product>();
    }
}
