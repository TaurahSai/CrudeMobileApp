using CrudeMobileApp.Model;
using CrudeMobileApp.Repositories;

namespace CrudeMobileApp.Services;

public class DetailOrderService(IDetailOrderRepository detailOrderRepository) : GenericService<DetailOrder>(detailOrderRepository)
{
    public async Task AddDetailOrdersAsync(List<DetailOrder> orderDetails) => await detailOrderRepository.AddRangeAsync(orderDetails);
}

