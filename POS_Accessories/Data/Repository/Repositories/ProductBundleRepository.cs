using Microsoft.EntityFrameworkCore;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Repositories
{
    public class ProductBundleRepository : Repository, IProductBundleRepository
    {
        public ProductBundleRepository(AccessoriesDbContext context) : base(context)
        {
        }

        public async Task CreateAsync(ProductBundleMap request)
        {
            _context.Add(request);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(ProductBundleMap request)
        {
            var category = await _context.Set<ProductBundleMap>()
                .Where(w => w.ProductBundleId == request.ProductBundleId)
                .FirstOrDefaultAsync();
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int categoryId)
        {
            var category = await GetByIdAsync(categoryId);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductBundleMap>> GetAllAsync()
        {
            return await _context.Set<ProductBundleMap>()
                .ToListAsync();
        }

        public async Task<ProductBundleMap> GetByIdAsync(int categoryId)
        {
            return await _context.Set<ProductBundleMap>()
                .Where(w => w.ProductBundleId == categoryId)
                .FirstOrDefaultAsync();
        }



        public async Task<IEnumerable<ProductBundleMap>> GetByPagingAsync(GetPagedSearch request)
        {
            return await _context.Set<ProductBundleMap>()
                .Where(w => w.IsActive == true)
                .ToListAsync();
        }


    }
}
