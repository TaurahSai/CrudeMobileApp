using CrudeMobileApp.Model;
using CrudeMobileApp.Models;
using CrudeMobileApp.Repositories;

namespace CrudeMobileApp.Shared
{
    public class DataService(IOrderRepository orderRepository, IGenericRepository<Customer> customerRepository, IGenericRepository<Product> productRepository, IDetailOrderRepository detailOrderRepository)
    {
        public async Task<List<Order>> GetOrdersWithCustomerAsync() => (await orderRepository.GetOrdersWithCustomersAsync()).ToList();

        public async Task AddOrderAsync(Order order, List<DetailOrder> orderDetails)
        {
            await orderRepository.AddAsync(order);
            foreach (var detail in orderDetails)
            {
                detail.OrderId = order.OrderId;
            }
            await detailOrderRepository.AddRangeAsync(orderDetails);
        }

        public async Task<List<Customer>> GetCustomersAsync() => (await customerRepository.GetAllAsync()).ToList();

        public async Task<List<Product>> GetProductsAsync() => (await productRepository.GetAllAsync()).ToList();
    }
}