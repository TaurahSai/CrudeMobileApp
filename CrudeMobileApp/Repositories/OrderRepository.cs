using CrudeMobileApp.Model;
using CrudeMobileApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace CrudeMobileApp.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> GetOrdersWithCustomersAsync()
        {
            return await _context.Orders.Include(o => o.Customer).ToListAsync();
        }
    }
}
