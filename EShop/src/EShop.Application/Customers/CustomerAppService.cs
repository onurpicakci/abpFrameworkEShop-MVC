using System;
using EShop.Products;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace EShop.Customers;

public class CustomerAppService 
    : CrudAppService<
        Customer,
        CustomerDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateCustomerDto>,
    ICustomerAppService
{
     
        public CustomerAppService(IRepository<Customer, Guid> repository)
            : base(repository)
        {

        }
}


