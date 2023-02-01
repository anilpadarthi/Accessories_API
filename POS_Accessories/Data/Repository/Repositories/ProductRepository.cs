using Microsoft.EntityFrameworkCore;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Repositories
{
    public class ProductRepository : Repository, IProductRepository
    {
        public ProductRepository(AccessoriesDbContext context) : base(context)
        {
        }

        public async Task CreateAsync(Product request)
        {
            _context.Add(request);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Product request)
        {
            var dbRecord = await _context.Set<Product>().Where(w => w.CategoryId == request.CategoryId).FirstOrDefaultAsync();
            dbRecord.ProductName = request.ProductName;
            dbRecord.ProductCode = request.ProductCode;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int id, string status)
        {
            var dbRecord = await GetByIdAsync(id);
            dbRecord.Status = status;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Set<Product>()
                .Where(cat => cat.Status != "D")
                .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            return await _context.Set<Product>()
                .Where(w => w.ProductId == productId)
                .FirstOrDefaultAsync();
        }

        public async Task<Product> GetByNameAsync(string productName)
        {
            return await _context.Set<Product>()
                .Where(w => w.ProductName.ToUpper() == productName.ToUpper())
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetByPagingAsync(GetPagedSearch request)
        {
            return await _context.Set<Product>()
                .Where(w => w.Status != "D")
                .ToListAsync();
        }

        public async Task<Product> GetProductAsync(int productId)
        {
            var result = await _context.Set<Product>()
                .Include(i => i.ProductPriceMaps)
                .Include(i => i.ProductColourMaps)
                .Include(i => i.ProductImageMaps)
                .Include(i => i.ProductBundleMaps)
                .Include(i => i.ProductSizeMaps)
                .Where(w => w.ProductId == productId)
                .FirstOrDefaultAsync();
            return result;
        }

    }
}
