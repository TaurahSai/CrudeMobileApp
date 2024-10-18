using CrudeMobileApp.Model;
using Microsoft.EntityFrameworkCore;

namespace CrudeMobileApp.Repositories
{
    public class OrderRepository(AppDbContext context) : GenericRepository<Order>(context), IOrderRepository
    {
        public async Task<IEnumerable<Order>> GetOrdersWithCustomersAsync() => await _context.Orders.Include(o => o.Customer).ToListAsync();
    }
}
