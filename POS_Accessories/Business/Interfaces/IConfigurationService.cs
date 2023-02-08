using POS_Accessories.Models;
using POS_Accessories.Models.Request;
using POS_Accessories.Models.Response;

namespace POS_Accessories.Business.Interfaces
{
    public interface IConfigurationService
    {
        Task<CommonResponse> CreateAsync(Configuration request);
        Task<CommonResponse> UpdateAsync(Configuration request);
        Task<CommonResponse> UpdateStatusAsync(int id, string status);
        Task<CommonResponse> GetByIdAsync(int id);
        Task<CommonResponse> GetAllAsync();
        Task<CommonResponse> GetByPagingAsync(GetPagedSearch request);
    }
}
