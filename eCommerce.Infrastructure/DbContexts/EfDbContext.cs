using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace eCommerce.Infrastructure.DbContexts
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        {            
        }
    }
}
