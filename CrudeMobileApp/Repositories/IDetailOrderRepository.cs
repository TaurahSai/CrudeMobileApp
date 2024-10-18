using CrudeMobileApp.Model;

namespace CrudeMobileApp.Repositories;

public interface IDetailOrderRepository :IGenericRepository<DetailOrder>
{
    Task AddRangeAsync(IEnumerable<DetailOrder> orderDetails);
}
