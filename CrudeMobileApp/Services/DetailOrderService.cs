using CrudeMobileApp.Model;
using CrudeMobileApp.Repositories;

namespace CrudeMobileApp.Services;

public class DetailOrderService(IDetailOrderRepository detailOrderRepository)
{
    private readonly IDetailOrderRepository _detailOrderRepository = detailOrderRepository;

    public async Task AddDetailOrdersAsync(List<DetailOrder> orderDetails) => await _detailOrderRepository.AddRangeAsync(orderDetails);
}
