using MariosSpecialtyProducts.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MariosSpecialtyProducts.Models
{
    public class MariosSpecialtyProductsContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseMySql(@"Server=localhost;Port=3306;database=mariosspecialtyproducts;uid=root;pwd=root;");

		protected override void OnModelCreating(ModelBuilder builder)
		{			
			base.OnModelCreating(builder);

			builder.Entity<ApplicationUser>(entity => entity.Property(m => m.Id)
				.HasMaxLength(255));
			builder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedEmail)
				.HasMaxLength(255));
			builder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedUserName)
				.HasMaxLength(255));

			builder.Entity<IdentityRole>(entity => entity.Property(m => m.Id)
				.HasMaxLength(255));
			builder.Entity<IdentityRole>(entity => entity.Property(m => m.NormalizedName)
				.HasMaxLength(255));

			builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider)
				.HasMaxLength(255));
			builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey)
				.HasMaxLength(255));
			builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId)
				.HasMaxLength(255));

			builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId)
				.HasMaxLength(255));
			builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId)
				.HasMaxLength(255));

			builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId)
				.HasMaxLength(255));
			builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider)
				.HasMaxLength(255));
			builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name)
				.HasMaxLength(255));

			builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.Id)
				.HasMaxLength(255));
			builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId)
				.HasMaxLength(255));
			builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.Id)
				.HasMaxLength(255));
			builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId)
				.HasMaxLength(255));
		}
    
    }
}