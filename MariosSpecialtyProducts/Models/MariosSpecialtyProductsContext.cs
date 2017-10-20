using Microsoft.EntityFrameworkCore;

namespace MariosSpecialtyProducts.Models
{
    public class MariosSpecialtyProductsContext : DbContext
    {
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseMySql(@"Server=localhost;Port=8889;database=MariosSpecialtyProducts;uid=root;pwd=root;");
    }
}