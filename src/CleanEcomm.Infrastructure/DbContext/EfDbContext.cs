namespace CleanEcomm.Infrastructure.DbContext;

public class EfDbContext : Microsoft.EntityFrameworkCore.DbContext {
    public DbSet<Order> Orders => Set<Order>();

    public EfDbContext(DbContextOptions<EfDbContext> options)
        : base(options) { }
}