using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities.Auditing;

namespace EShop.Baskets;

public class Basket : AuditedAggregateRoot<Guid>
{
    public Guid CustomerId { get; set; }

    public List<BasketItem> BasketItems { get; set; }


    private Basket()
    {
    }

    public Basket(Guid id)
        : base(id)
    {
        BasketItems = new List<BasketItem>();
    }

    public void AddProduct(Guid productId, int count = 1)
    {
        if (count < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "Product count should be 1 or more!");
        }

        var item = BasketItems.FirstOrDefault(x => x.ProductId == productId);
        if (item == null)
        {
            BasketItems.Add(new BasketItem(productId, count));
        }
        else
        {
            item.ProductCount += count;
        }
    }

    public int GetProductCount(Guid productId)
    {
        var item = BasketItems.FirstOrDefault(x => x.ProductId == productId);
        return item?.ProductCount ?? 0;
    }

    public void Merge(Basket basket)
    {
        foreach (var item in basket.BasketItems)
        {
            AddProduct(item.ProductId, item.ProductCount);
        }
    }
}



