using POS_Accessories.Business.Interfaces;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;
using POS_Accessories.Models.Response;
using System.Net;

namespace POS_Accessories.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<CommonResponse> CreateCategoryAsync(Category request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _categoryRepository.GetCategoryByNameAsync(request.CategoryName);
                if (result != null)
                {
                    response.data = "Category name already exist";
                    response.statusCode = HttpStatusCode.Conflict;
                    response.status = false;
                }
                else
                {
                    await _categoryRepository.CreateCategoryAsync(request);
                    response.data = "Created successfully";
                    response.statusCode = HttpStatusCode.Created;
                    response.status = true;
                    response.count = 1;
                }
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }

        public async Task<IEnumerable<string>> DeleteCategoryAsync(int categoryId)
        {
            return await _categoryRepository.DeleteCategoryAsync(categoryId);
        }

        public async Task<CommonResponse> UpdateCategoryAsync(Category request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _categoryRepository.GetCategoryByNameAsync(request.CategoryName);
                if (result != null)
                {
                    response.message = "Category name already exist";
                    response.statusCode = HttpStatusCode.Conflict;
                    response.status = false;
                }
                else
                {
                    await _categoryRepository.UpdateCategoryAsync(request);
                    response.message = "Updated successfully";
                    response.statusCode = HttpStatusCode.OK;
                    response.status = true;
                }
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
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
