using POS_Accessories.Models;
using POS_Accessories.Models.Request;
using POS_Accessories.Models.Response;

namespace POS_Accessories.Business.Interfaces
{
    public interface ICouponService
    {
        Task<CommonResponse> CreateAsync(CouponRequestModel request);
        Task<CommonResponse> UpdateAsync(CouponRequestModel request);
        Task<CommonResponse> UpdateStatusAsync(int id, string status);
        Task<CommonResponse> GetByIdAsync(int id);
        Task<CommonResponse> GetAllAsync();
        Task<CommonResponse> GetByPagingAsync(GetPagedSearch request);
    }
}
