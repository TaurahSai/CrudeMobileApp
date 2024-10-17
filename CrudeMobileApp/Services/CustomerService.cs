using CrudeMobileApp.Models;
using CrudeMobileApp.Repositories;

namespace CrudeMobileApp.Services;

public class CustomerService(IGenericRepository<Customer> customerRepository)
{
    private readonly IGenericRepository<Customer> _customerRepository = customerRepository;

    public async Task<List<Customer>> GetCustomersAsync() => (await _customerRepository.GetAllAsync()).ToList();
}
