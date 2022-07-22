using delivery_system_api.Domain.Models;
using delivery_system_api.Domain.Repositories;
using delivery_system_api.Extensions;
using delivery_system_api.Persistence.Contexts;

namespace delivery_system_api.Persistence.Repositories
{
    public class ViechleRepository : IViechleRepository
    {
        private readonly DeliverySystemDbContext _context;

        public ViechleRepository(DeliverySystemDbContext context)
        {
            _context = context; 
        }
        public async Task AddAsync(Viechle viechle)
        {
             await _context.viechles.AddAsync(viechle) ;
        }

        public async Task Delete(Viechle viechle)
        {
             _context.viechles.Remove(viechle);
        }

        public async Task<Viechle> GetByIdAsync(int id)
        {
            return await  _context.viechles.FindAsync(id);
        }

        public async Task<IEnumerable<Viechle>> ListAsync()
        {
            return  _context.viechles.ToList();
        }

        public async Task Update(Viechle viechle)
        {
            _context.DetachLocal<Viechle>(viechle,viechle.Id);
            _context.viechles.Update(viechle);
        }
    }
}
