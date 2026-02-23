using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PointOfSale.DataModel;

namespace PointOfSale.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
   
        }
        public DbSet<Product> Products { get; set; } = default;
        public DbSet<Catagory> Catagories { get; set; } = default;
        public DbSet<Supplier> suppliers { get; set; } = default;
    }
}
