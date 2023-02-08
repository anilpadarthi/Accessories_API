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

        public async Task<IEnumerable<Product>> GetByPagingAsync(GetPagedSearch request)
        {
            var query = _context.Set<Product>()
                .Where(w => w.Status != "D");

            if (request.categoryId.HasValue && request.categoryId > 0)
            {
                query = query.Where(w => w.CategoryId == request.categoryId);
            }
            if (request.subCategoryId.HasValue && request.subCategoryId > 0)
            {
                query = query.Where(w => w.SubCategoryId == request.subCategoryId);
            }
            if (!string.IsNullOrEmpty(request.searchText))
            {
                query = query.Where(w => w.ProductName.Contains(request.searchText) || w.ProductCode.Contains(request.searchText));
            }

            var result = await query
                .OrderBy(o => o.ProductName)
                .Skip((request.pageNo - 1) * request.pageSize)
                .Take(request.pageSize)
                .ToListAsync();

            return result;
        }

        public async Task<int> GetTotalCountAsync(GetPagedSearch request)
        {
            var query = _context.Set<Product>()
               .Where(w => w.Status != "D");

            if (!string.IsNullOrEmpty(request.searchText))
            {
                query = query.Where(w => w.ProductName.Contains(request.searchText) || w.ProductCode.Contains(request.searchText));
            }
            return await query.CountAsync();
        }

    }
}
