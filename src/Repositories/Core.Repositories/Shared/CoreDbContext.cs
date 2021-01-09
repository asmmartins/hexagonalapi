using Core.Domain.Aggregates.Terminals;
using Microsoft.EntityFrameworkCore;

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
