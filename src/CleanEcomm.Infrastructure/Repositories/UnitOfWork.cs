using CleanEcomm.Infrastructure.DbContext;

namespace CleanEcomm.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork {
    private readonly EfDbContext _context;

    public UnitOfWork(EfDbContext context) {
        _context = context;
    }

    public async Task CommitAsync(CancellationToken ct = default) {
        await _context.SaveChangesAsync(ct);
    }
}