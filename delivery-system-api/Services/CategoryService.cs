using delivery_system_api.Domain.Models;
using delivery_system_api.Domain.Repositories;
using delivery_system_api.Domain.Services;
using delivery_system_api.Domain.Services.Communications;
using Microsoft.AspNetCore.JsonPatch;

namespace delivery_system_api.Services
{
    public class CategoryService : ICategoryService

    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository ,  IUnitOfWork unitOfWork)
        {
           _categoryRepository = categoryRepository;
           _unitOfWork = unitOfWork;
        }


        public Task<IEnumerable<Category>> GetCategoriesAsync()
        {
           return _categoryRepository.ListAsync();  
        }
        public async Task<CategoryResponse> AddCategoryAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(category);

            }
            catch (Exception ex)
            {

              return new CategoryResponse($"could not add category : {ex.Message}");
            }
           
        }

        public async Task<CategoryResponse> DeleteCategoryAsync(int categoryId)
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(categoryId);
            if (existingCategory == null)
            {
                return new CategoryResponse("Category not found!");
            }
            try
            {
               await _categoryRepository.Delete(existingCategory);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(true, string.Empty, null);
            }
            catch (Exception  ex)
            {
                return new CategoryResponse(ex.Message);    
            }
        }

        public async Task<CategoryResponse> UpdateCategoryAsync(Category category)
        {
          var  existingCategory =await _categoryRepository.GetByIdAsync(category.Id);
            if(existingCategory == null)
            {
                return new CategoryResponse("Category not found!");
            }
            try
            {
               await   _categoryRepository.Update(category);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(category);
                
            }
            catch (Exception ex)
            {

                return  new CategoryResponse($"Could not update category : {ex.Message}");
            }
        }
        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if(category == null)
            {
                throw new Exception("Category Not found");
            }
            return category; 
        }

        public async Task<CategoryResponse> PatchCategoryAsync(int categoryId, JsonPatchDocument categoryPatch)
        {
            try
            {
               await  _categoryRepository.Patch(categoryId, categoryPatch);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(true, String.Empty, null);
            }
            catch (Exception ex)
            {

                return new CategoryResponse($"could not updage category: {ex}");
            }
        }
    }
}
