using CrudeMobileApp.Model;

namespace CrudeMobileApp.Repositories;

public class DetailOrderRepository(AppDbContext context) : GenericRepository<DetailOrder>(context), IDetailOrderRepository
{
    public async Task AddRangeAsync(IEnumerable<DetailOrder> detailOrders)
    {
        await _context.Set<DetailOrder>().AddRangeAsync(detailOrders);
        await _context.SaveChangesAsync();
    }
}
