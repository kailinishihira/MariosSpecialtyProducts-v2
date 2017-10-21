using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MariosSpecialtyProducts.Models
{
    public class EFProductRepository : IProductRepository
    {
        public EFProductRepository(MariosSpecialtyProductsContext connection = null)
        {
            if (connection == null)
            {
                this.db = new MariosSpecialtyProductsContext();
            }
            else
            {
                this.db = connection;
            }
        }
        MariosSpecialtyProductsContext db = new MariosSpecialtyProductsContext();

        public IQueryable<Product> Products
        { get { return db.Products; } }

		public IQueryable<Review> Reviews
		{ get { return db.Reviews; } }


		public Product Edit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return product;
        }

        public void Remove(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public Product Save(Product product)
        {   
            db.Products.Add(product);
            db.SaveChanges();    
            return product;
        }

        public void DeleteAll()
        {
            db.Products.RemoveRange(db.Products.ToList());
            db.SaveChanges();
        }

        //public int AverageRatings ()
        //{
            
        //    int totalRatings;
        //    int numberOfRatings;


        //}
    }
}
