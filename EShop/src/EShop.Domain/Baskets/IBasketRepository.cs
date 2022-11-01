using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace EShop.Baskets;

public interface IBasketRepository : IRepository
{
    Task<Basket> GetAsync(Guid id);
}

