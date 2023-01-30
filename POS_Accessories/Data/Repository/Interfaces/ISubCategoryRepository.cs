using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Interfaces
{
    public interface ISubCategoryRepository: IRepository
    {
        Task CreateAsync(SubCategory request);
        Task UpdateAsync(SubCategory request);
        Task UpdateStatusAsync(int id, string status);
        Task<SubCategory> GetByIdAsync(int subCategoryId);
        Task<SubCategory> GetByNameAsync(string subCategoryName);
        Task<IEnumerable<SubCategory>> GetAllAsync(int categoryId);
        Task<IEnumerable<SubCategory>> GetByPagingAsync(GetPagedRequest request);


    }
}
