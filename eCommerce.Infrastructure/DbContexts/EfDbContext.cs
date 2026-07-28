using eCommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.DbContexts
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> Users => Set<ApplicationUser>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(EfDbContext).Assembly);
        }
    }
}
