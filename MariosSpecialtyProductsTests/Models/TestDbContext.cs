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
			options.UseMySql(@"Server=localhost;Port=8889;database=MariosSpecialtyProducts_tests;uid=root;pwd=root;");
		}
    }
}
