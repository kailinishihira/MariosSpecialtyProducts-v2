using System;
using Microsoft.EntityFrameworkCore;
using MariosSpecialtyProducts.Models;

namespace MariosSpecialtyProductsTests.Models
{
    public class TestDbContext : MariosSpecialtyProductsContext
    {
        public override DbSet<Review> Reviews { get; set; }
        public override DbSet<Product> Products { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseMySql(@"Server=localhost;Port=3306;database=mariosspecialtyproducts_tests;uid=root;pwd=root;");
		}
    }
}
