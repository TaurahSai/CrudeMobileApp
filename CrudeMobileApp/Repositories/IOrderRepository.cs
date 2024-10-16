using CrudeMobileApp.Model;

namespace CrudeMobileApp.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersWithCustomersAsync();
    }

}
