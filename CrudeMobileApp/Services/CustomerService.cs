using CrudeMobileApp.Models;
using CrudeMobileApp.Repositories;

namespace CrudeMobileApp.Services;

public class CustomerService(IGenericRepository<Customer> repository) : GenericService<Customer>(repository)
{
}


