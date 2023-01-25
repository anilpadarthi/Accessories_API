using POS_Accessories.Models;
using POS_Accessories.Models.Request;
using POS_Accessories.Models.Response;

namespace POS_Accessories.Business.Interfaces
{
    public interface ICategoryService
    {
        Task<CommonResponse> CreateCategoryAsync(Category request);
        Task<CommonResponse> UpdateCategoryAsync(Category request);
        Task<IEnumerable<string>> DeleteCategoryAsync(int categoryId);
        Task<Category> GetCategoryAsync(int categoryId);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<IEnumerable<Category>> GetPagedCategories(GetPagedRequest request);
    }
}
