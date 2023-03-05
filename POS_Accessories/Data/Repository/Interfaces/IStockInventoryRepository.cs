using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Interfaces
{
    public interface IStockInventoryRepository : IRepository
    {
        Task CreateAsync(StockInventory request);
        Task UpdateAsync(StockInventory request);
        Task UpdateStatusAsync(int stockId, string status);
        Task<StockInventory> GetByIdAsync(int stockId);
        Task<IEnumerable<StockInventory>> GetAllAsync();
        Task<IEnumerable<StockInventory>> GetByPagingAsync(GetPagedSearch request);
        Task<int> GetTotalCountAsync(GetPagedSearch request);
    }
}
