using POS_Accessories.Models;
using POS_Accessories.Models.Request;
using POS_Accessories.Models.Response;

namespace POS_Accessories.Business.Interfaces
{
    public interface ISubCategoryService
    {
        Task<CommonResponse> CreateAsync(SubCategory request);
        Task<CommonResponse> UpdateAsync(SubCategory request);
        Task<CommonResponse> UpdateStatusAsync(int id, string status);
        Task<CommonResponse> GetByIdAsync(int id);
        Task<CommonResponse> GetAllAsync(int categoryId);
        Task<CommonResponse> GetByPagingAsync(GetPagedRequest request);
    }
}
