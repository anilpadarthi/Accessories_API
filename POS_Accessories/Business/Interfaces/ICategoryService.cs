using POS_Accessories.Models;
using POS_Accessories.Models.Request;
using POS_Accessories.Models.Response;

namespace POS_Accessories.Business.Interfaces
{
    public interface ICategoryService
    {
        Task<CommonResponse> CreateAsync(CategoryRequestModel request);
        Task<CommonResponse> UpdateAsync(CategoryRequestModel request);
        Task<CommonResponse> UpdateStatusAsync(int categoryId, string status);
        Task<CommonResponse> GetByIdAsync(int categoryId);
        Task<CommonResponse> GetAllAsync();
        Task<CommonResponse> GetByPagingAsync(GetPagedSearch request);
    }
}
