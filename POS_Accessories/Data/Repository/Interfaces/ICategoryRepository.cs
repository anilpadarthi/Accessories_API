using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Interfaces
{
    public interface ICategoryRepository : IRepository
    {
        Task CreateAsync(Category request);
        Task UpdateAsync(Category request);
        Task UpdateStatusAsync(int categoryId, string status);
        Task<Category> GetByIdAsync(int categoryId);
        Task<Category> GetByNameAsync(string categoryName);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<IEnumerable<Category>> GetByPagingAsync(GetPagedRequest request);
    }
}
