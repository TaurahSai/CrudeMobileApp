using CrudeMobileApp.Model;
using CrudeMobileApp.Repositories;

namespace CrudeMobileApp.Services;

public class OrderService(IOrderRepository orderRepository, IDetailOrderRepository detailOrderRepository) : GenericService<Order>(orderRepository)
{
    public async Task<List<Order>> GetOrdersWithCustomerAsync()
    {
        return (await orderRepository.GetOrdersWithCustomersAsync()).ToList();
    }

    public async Task AddOrderAsync(Order order, List<DetailOrder> orderDetails)
    {
        await orderRepository.AddAsync(order);
        foreach (var detail in orderDetails)
        {
            detail.OrderId = order.OrderId;
        }
        await detailOrderRepository.AddRangeAsync(orderDetails);
    }

    public async Task DeleteOrderAsync(Order order)
    {
        await orderRepository.DeleteAsync(order);
    }
}

