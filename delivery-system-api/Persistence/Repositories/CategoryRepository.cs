using delivery_system_api.Domain.Models;
using delivery_system_api.Domain.Repositories;
using delivery_system_api.Extensions;
using delivery_system_api.Persistence.Contexts;
using Microsoft.AspNetCore.JsonPatch;

namespace delivery_system_api.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DeliverySystemDbContext _context;

        public CategoryRepository(DeliverySystemDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> ListAsync()
        {
            return _context.categories.ToList();
        }
        public async Task AddAsync(Category category)
        {
            await _context.categories.AddAsync(category);

        }
        public async Task<Category> GetByIdAsync(int id)
          
        {
            return  await _context.categories.FindAsync(id); 
        }

        public async Task Update(Category category)
        {
           _context.DetachLocal<Category>(category , category.Id);
             _context.categories.Update(category);
        }
        public async Task  Delete(Category category)
        {
             _context.categories.Remove(category);  
        }
      public async Task Patch(int id , JsonPatchDocument categoryPatch)
        {
            var category  = await GetByIdAsync(id); 
            if(category != null)
            {
                categoryPatch.ApplyTo(category);
                
            }
        }

    }
}
