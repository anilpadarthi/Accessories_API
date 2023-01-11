using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Interfaces
{
    public interface ISubCategoryRepository: IRepository
    {
        Task<IEnumerable<string>> CreateSubCategoryAsync(SubCategory request);
        Task<IEnumerable<string>> UpdateSubCategoryAsync(SubCategory request);
        Task<IEnumerable<string>> DeleteSubCategoryAsync(int categoryId);
        Task<SubCategory> GetSubCategoryAsync(int categoryId);
        Task<IEnumerable<SubCategory>> GetAllSubCategoriesAsync();
        Task<IEnumerable<SubCategory>> GetPagedSubCategoriesAsync(GetPagedRequest request);
    }
}
