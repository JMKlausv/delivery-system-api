using delivery_system_api.Domain.Models;
using delivery_system_api.Domain.Repositories;
using delivery_system_api.Persistence.Contexts;

namespace delivery_system_api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DeliverySystemDbContext  _context;

        public UserRepository(DeliverySystemDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User user)
        {
            await _context.users.AddAsync(user);   
        }

        public User FindByEmailAsync(string email)
        {
            return   _context.users.SingleOrDefault(u => u.Email == email);
        }
    }
}
