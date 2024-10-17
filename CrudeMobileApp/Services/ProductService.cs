using CrudeMobileApp.Model;
using CrudeMobileApp.Repositories;

namespace CrudeMobileApp.Services
{
    public class ProductService(IGenericRepository<Product> productRepository)
    {
        private readonly IGenericRepository<Product> _productRepository = productRepository;

        public async Task<List<Product>> GetProductsAsync() => (await _productRepository.GetAllAsync()).ToList();
    }
}
