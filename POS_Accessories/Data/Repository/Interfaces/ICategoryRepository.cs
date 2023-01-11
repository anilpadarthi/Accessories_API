using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Interfaces
{
    public interface ICategoryRepository: IRepository
    {
        Task<IEnumerable<string>> CreateCategoryAsync(Category request);
        Task<IEnumerable<string>> UpdateCategoryAsync(Category request);
        Task<IEnumerable<string>> DeleteCategoryAsync(int categoryId);
        Task<Category> GetCategoryAsync(int categoryId);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<IEnumerable<Category>> GetPagedCategories(GetPagedRequest request);
    }
}
