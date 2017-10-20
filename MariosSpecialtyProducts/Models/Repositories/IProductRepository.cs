using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MariosSpecialtyProducts.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        IQueryable<Review> Reviews { get; }
        Product Save(Product product);
        Product Edit(Product product);
        void Remove(Product product);
    }
}
