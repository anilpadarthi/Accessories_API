using POS_Accessories.Models;
using POS_Accessories.Models.Response;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Interfaces
{
    public interface IInventoryRepository : IRepository
    {
        Task<IEnumerable<WareHouseResult>> GetWareHouseResultAsync(GetPagedSearch request);
        Task<IEnumerable<StockPurchaseHistoryResult>> GetStockPurchaseHistoyResultAsync(GetPagedSearch request);
        Task<int> GetTotalCountAsync(GetPagedSearch request);
    }
}
