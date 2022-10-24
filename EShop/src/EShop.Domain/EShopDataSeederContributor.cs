using System;
using System.Threading.Tasks;
using EShop.Categories;
using EShop.Products;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace EShop;

public class EShopDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{

    private readonly IRepository<Product, Guid> _productRepository;

    private readonly IRepository<Category, Guid> _categoryRepository;



    public EShopDataSeederContributor(IRepository<Product,Guid> productRepository, IRepository<Category,Guid> categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;

    }
    public async Task SeedAsync(DataSeedContext context)
    {
        Category category;
        if (await _categoryRepository.GetCountAsync() <= 0)
        {
            category = await _categoryRepository.InsertAsync(
                new Category
                {
                    CategoryName = "Electronic"
                },
                autoSave: true
                );

                category = await _categoryRepository.InsertAsync(
                new Category
                {
                    CategoryName = "Fashion"

                },
                autoSave: true
                );
                }
        else
        {
            category = await _categoryRepository.FirstAsync();
        }

        if (await _productRepository.GetCountAsync() <= 0 )
        {
            await _productRepository.InsertAsync(
                new Product
                {
                    Code = "PC",
                    Name = "MSI Laptop",
                    Price = 15000.0f,
                    StockCount = 10,
                    ProductDescription = "8gb ram, 256gb m2 ssd",
                    CategoryId = category.Id
                    
                    


                },
                autoSave: true); 
        }
    }
}

