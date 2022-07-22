using delivery_system_api.Domain.Models;

namespace delivery_system_api.Domain.Repositories
{
    public interface IUserRepository
    {
      
        Task AddAsync(User user);
        User FindByEmailAsync(string email);
      
    }
}
