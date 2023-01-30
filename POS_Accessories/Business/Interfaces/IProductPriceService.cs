using POS_Accessories.Models;
using POS_Accessories.Models.Request;
using POS_Accessories.Models.Response;

namespace POS_Accessories.Business.Interfaces
{
    public interface IProductPriceService
    {
        Task<CommonResponse> CreateAsync(ProductPriceMap request);
        Task<CommonResponse> UpdateAsync(ProductPriceMap request);
        Task<CommonResponse> DeleteAsync(int productPriceMapId);
        Task<CommonResponse> GetByIdAsync(int productPriceMapId);
        Task<CommonResponse> GetAllAsync(int productId);
        Task<CommonResponse> GetByPagingAsync(GetPagedRequest request);
    }
}
