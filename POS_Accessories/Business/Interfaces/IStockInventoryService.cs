using POS_Accessories.Models.Request;
using POS_Accessories.Models.Response;
using POS_Accessories.Models;

namespace POS_Accessories.Business.Interfaces
{
    public interface IStockInventoryService
    {
        Task<CommonResponse> CreateAsync(StockInventory request);
        Task<CommonResponse> UpdateAsync(StockInventory request);
        Task<CommonResponse> UpdateStatusAsync(int stockId, string status);
        Task<CommonResponse> GetByIdAsync(int stockId);
        Task<CommonResponse> GetAllAsync();
        Task<CommonResponse> GetByPagingAsync(GetPagedSearch request);
     }
}
