using CrudeMobileApp.Model;

namespace CrudeMobileApp.Repositories;

public interface IDetailOrderRepository
{
    Task AddRangeAsync(IEnumerable<DetailOrder> orderDetails);
}
