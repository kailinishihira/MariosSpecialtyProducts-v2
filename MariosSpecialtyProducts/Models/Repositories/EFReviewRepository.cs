using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MariosSpecialtyProducts.Models
{
    public class EFReviewRepository : IReviewRepository
    {
        public EFReviewRepository(MariosSpecialtyProductsContext connection = null)
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

        public IQueryable<Review> Reviews
        { get {return db.Reviews;} }

		public IQueryable<Product> Products
		{ get { return db.Products; } }

        public Review Edit(Review review)
        {
            db.Entry(review).State = EntityState.Modified;
            db.SaveChanges();
            return review;
        }

        public void Remove(Review review)
        {
            db.Reviews.Remove(review);
            db.SaveChanges();
        }

        public Review Save(Review review)
        {         
            db.Reviews.Add(review);
            db.SaveChanges();
            return review;
        }

        public void DeleteAll()
        {
            db.Reviews.RemoveRange(db.Reviews.ToList());
            db.SaveChanges();
        }
    }
}
