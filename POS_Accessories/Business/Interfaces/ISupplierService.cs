using POS_Accessories.Models;
using POS_Accessories.Models.Request;
using POS_Accessories.Models.Response;

namespace POS_Accessories.Business.Interfaces
{
    public interface ISupplierService
    {
        Task<CommonResponse> CreateAsync(SupplierRequestModel request);
        Task<CommonResponse> UpdateAsync(SupplierRequestModel request);
        Task<CommonResponse> UpdateStatusAsync(int SupplierId, string status);
        Task<CommonResponse> GetByIdAsync(int SupplierId);
        Task<CommonResponse> GetAllAsync();
        Task<CommonResponse> GetByPagingAsync(GetPagedSearch request);
    }
}
