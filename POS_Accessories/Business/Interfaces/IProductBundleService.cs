using POS_Accessories.Models;
using POS_Accessories.Models.Request;
using POS_Accessories.Models.Response;

namespace POS_Accessories.Business.Interfaces
{
    public interface IProductBundleService
    {
        Task<CommonResponse> CreateAsync(ProductBundleMap request);
        Task<CommonResponse> UpdateAsync(ProductBundleMap request);
        Task<CommonResponse> DeleteAsync(int categoryId);
        Task<CommonResponse> GetByIdAsync(int categoryId);
        Task<CommonResponse> GetAllAsync();
        Task<CommonResponse> GetByPagingAsync(GetPagedSearch request);
    }
}
