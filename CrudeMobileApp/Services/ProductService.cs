using CrudeMobileApp.Model;
using CrudeMobileApp.Repositories;

namespace CrudeMobileApp.Services
{
    public class ProductService(IGenericRepository<Product> repository) : GenericService<Product>(repository)
    {
    }
}
