using CrudeMobileApp.Model;
using Microsoft.EntityFrameworkCore;

namespace CrudeMobileApp.Shared
{
    public class DataService
    {
        private readonly AppDbContext _context;

        public DataService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _context.Orders.Include(o => o.Customer).ToListAsync();
        }

        public async Task AddOrderAsync(Order order, List<DetailOrder> orderDetails)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            // Ensure the OrderId is set for each OrderDetail
            foreach (var detail in orderDetails)
            {
                detail.OrderId = order.OrderId;
            }

            await _context.DetailOrders.AddRangeAsync(orderDetails);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}