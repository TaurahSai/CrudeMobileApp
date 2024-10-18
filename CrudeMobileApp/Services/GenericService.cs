using CrudeMobileApp.Repositories;

namespace CrudeMobileApp.Services
{
    public class GenericService<T>(IGenericRepository<T> repository) where T : class
    {
        public async Task<T> GetByIdAsync(string id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task AddAsync(T entity)
        {
            await repository.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await repository.DeleteAsync(entity);
        }
    }
}
