using delivery_system_api.Domain.Models;
using delivery_system_api.Domain.Services.Communications;
using Microsoft.AspNetCore.JsonPatch;

namespace delivery_system_api.Domain.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int categoryId);
        Task<CategoryResponse> AddCategoryAsync(Category category);
        Task<CategoryResponse> UpdateCategoryAsync(Category category);    
        Task<CategoryResponse> DeleteCategoryAsync(int categoryId);
        Task<CategoryResponse> PatchCategoryAsync(int categoryId, JsonPatchDocument categoryPatch);


    }
}
