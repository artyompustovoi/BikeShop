using Microsoft.EntityFrameworkCore;

namespace NiceBikeShopBackend.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Product> Orders => Set<Product>();
        public DbSet<Product> Products => Set<Product>();
        public AppDBContext(
            DbContextOptions<AppDBContext> options) : base(options) { }
    }
}
