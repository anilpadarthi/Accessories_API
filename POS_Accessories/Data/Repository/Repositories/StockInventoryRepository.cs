using Microsoft.EntityFrameworkCore;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Repositories
{
    public class StockInventoryRepository : Repository, IStockInventoryRepository
    {
        public StockInventoryRepository(AccessoriesDbContext context) : base(context)
        {
        }

        public async Task CreateAsync(StockInventory request)
        {
            _context.Add(request);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(StockInventory request)
        {
            var dbRecord = await _context.Set<StockInventory>()
                .Where(w => w.StockInventoryId == request.StockInventoryId)
                .FirstOrDefaultAsync();
            dbRecord.BuyPrice = request.BuyPrice;
            dbRecord.Qty = request.Qty;
            dbRecord.InvoiceNumber= request.InvoiceNumber;
            dbRecord.SupplierId= request.SupplierId;
            dbRecord.ProductId = request.ProductId;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int stockId, string status)
        {
            var dbRecord = await GetByIdAsync(stockId);
            dbRecord.Status = status;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<StockInventory>> GetAllAsync()
        {
            return await _context.Set<StockInventory>()
                .Where(w => w.Status != "D")
                .ToListAsync();
        }

        public async Task<StockInventory> GetByIdAsync(int stockId)
        {
            return await _context.Set<StockInventory>()
                .Where(w => w.StockInventoryId == stockId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<StockInventory>> GetByPagingAsync(GetPagedSearch request)
        {
            var query = _context.Set<StockInventory>()
                .Where(w => w.Status != "D");

            if (!string.IsNullOrEmpty(request.searchText))
            {
                var productsFiltered = _context.Set<Product>()
                .Where(w => w.ProductName.Contains(request.searchText)).Select(a => a.ProductId).ToList();
                query = query.Where(w => productsFiltered.Contains(w.ProductId));
            }
            var result = await query
                .OrderBy(o => o.StockInventoryId)
                .Skip((request.pageNo - 1) * request.pageSize)
                .Take(request.pageSize)
                .ToListAsync();

            return result;
        }

        public async Task<int> GetTotalCountAsync(GetPagedSearch request)
        {
            var query = _context.Set<StockInventory>()
               .Where(w => w.Status != "D");

            return await query.CountAsync();
        }
    }
}
