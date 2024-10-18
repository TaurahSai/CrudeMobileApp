using CrudeMobileApp.Model;
using CrudeMobileApp.Repositories;

namespace CrudeMobileApp.Services;

public class DetailOrderService : GenericService<DetailOrder>
{
    private readonly IDetailOrderRepository _detailOrderRepository;

    public DetailOrderService(IDetailOrderRepository detailOrderRepository): base(detailOrderRepository)
    {
        _detailOrderRepository = detailOrderRepository;
    }

    public async Task AddDetailOrdersAsync(List<DetailOrder> orderDetails)
    {
        await _detailOrderRepository.AddRangeAsync(orderDetails);
    }
}

