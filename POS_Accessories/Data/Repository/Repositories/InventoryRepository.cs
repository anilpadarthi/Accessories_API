using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;
using POS_Accessories.Models.Response;

namespace POS_Accessories.Data.Repository.Repositories
{
    public class InventoryRepository : Repository, IInventoryRepository
    {
        public InventoryRepository(AccessoriesDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<WareHouseResult>> GetWareHouseResultAsync(GetPagedSearch request)
        {
            var list = await ExecuteStoredProcedureAsync<WareHouseResult>("exec GetWareHouseResult @productNameOrCode", new SqlParameter("@productNameOrCode", request.searchText));
            return list.ToList();
        }

        public async Task<IEnumerable<StockPurchaseHistoryResult>> GetStockPurchaseHistoyResultAsync(GetPagedSearch request)
        {
            var list = await ExecuteStoredProcedureAsync<StockPurchaseHistoryResult>("exec GetStockPurchaseHistoyResult @productId", new SqlParameter("productId", request.id));
            return list.ToList();
        }

        public async Task<int> GetTotalCountAsync(GetPagedSearch request)
        {
            var query = _context.Set<Category>()
               .Where(w => w.Status != "D");

            if (!string.IsNullOrEmpty(request.searchText))
            {
                query = query.Where(w => w.CategoryName.Contains(request.searchText));
            }
            return await query.CountAsync();
        }

    }
}
