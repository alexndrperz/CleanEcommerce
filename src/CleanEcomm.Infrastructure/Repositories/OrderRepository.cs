using CleanEcomm.Infrastructure.DbContext;

namespace CleanEcomm.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository {
    private readonly EfDbContext _context;

    public OrderRepository(EfDbContext context) {
        _context = context;
    }

    public async Task AddAsync(Order order) {
        await _context.Orders.AddAsync(order);
    }

    public async Task<Order?> GetByIdAsync(Guid id) {
        return await _context.Orders
            .FirstOrDefaultAsync(o => o.Id == id);
    }
}