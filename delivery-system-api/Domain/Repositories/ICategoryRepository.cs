using delivery_system_api.Domain.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace delivery_system_api.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();
        Task AddAsync(Category category);   
        Task Update(Category category);    
        Task<Category> GetByIdAsync(int id);
        Task Delete(Category category);
        Task Patch(int id, JsonPatchDocument categoryPatch);

    }
}
