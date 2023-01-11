using POS_Accessories.Business.Interfaces;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<string>> CreateCategoryAsync(Category request)
        {
            return await _categoryRepository.CreateCategoryAsync(request);
        }

        public async Task<IEnumerable<string>> DeleteCategoryAsync(int categoryId)
        {            
            return await _categoryRepository.DeleteCategoryAsync(categoryId);
        }

        public async Task<IEnumerable<string>> UpdateCategoryAsync(Category request)
        {
            var category = await _categoryRepository.GetCategoryAsync(request.CategoryId);
            category.CategoryName = request.CategoryName;
            category.Image = request.Image;
            return await _categoryRepository.UpdateCategoryAsync(request);            
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllCategoriesAsync();
        }

        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            return await _categoryRepository.GetCategoryAsync(categoryId);
        }

        public async Task<IEnumerable<Category>> GetPagedCategories(GetPagedRequest request)
        {
            return await _categoryRepository.GetPagedCategories(request);
        }
    }
}
