using CrudeMobileApp.Model;
using CrudeMobileApp.Repositories;

namespace CrudeMobileApp.Services;

public class OrderService(IOrderRepository orderRepository, IDetailOrderRepository detailOrderRepository)
{
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly IDetailOrderRepository _detailOrderRepository = detailOrderRepository;

    public async Task<List<Order>> GetOrdersWithCustomerAsync() => (await _orderRepository.GetOrdersWithCustomersAsync()).ToList();

    public async Task AddOrderAsync(Order order, List<DetailOrder> orderDetails)
    {
        await _orderRepository.AddAsync(order);
        foreach (var detail in orderDetails)
        {
            detail.OrderId = order.OrderId;
        }
        await _detailOrderRepository.AddRangeAsync(orderDetails);
    }
}
