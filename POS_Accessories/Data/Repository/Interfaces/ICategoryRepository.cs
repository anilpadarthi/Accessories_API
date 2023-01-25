using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Interfaces
{
    public interface ICategoryRepository: IRepository
    {
        Task CreateCategoryAsync(Category request);
        Task UpdateCategoryAsync(Category request);
        Task<IEnumerable<string>> DeleteCategoryAsync(int categoryId);
        Task<Category> GetCategoryAsync(int categoryId);
        Task<Category> GetCategoryByNameAsync(string categoryName);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<IEnumerable<Category>> GetPagedCategories(GetPagedRequest request);
    }
}
