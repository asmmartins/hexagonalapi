using Microsoft.EntityFrameworkCore;
using Core.Domain.Aggregates.Terminals;

namespace Core.Repositories.Shared
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Terminal> Terminal { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
        }
    }
}
