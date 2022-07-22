using delivery_system_api.Domain.Repositories;
using delivery_system_api.Persistence.Contexts;

namespace delivery_system_api.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DeliverySystemDbContext _context;

        public UnitOfWork(DeliverySystemDbContext context)
        {
           _context = context;
        }
        public async Task CompleteAsync()
        {
          await   _context.SaveChangesAsync();
        }
    }
}
