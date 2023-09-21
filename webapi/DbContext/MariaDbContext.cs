using Microsoft.EntityFrameworkCore;

namespace webapi.DbContext;

public partial class MariaDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public MariaDbContext(DbContextOptions<MariaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Wealth> Wealths { get; set; }
}