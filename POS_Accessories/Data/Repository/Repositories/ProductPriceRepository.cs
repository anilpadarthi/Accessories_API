using Microsoft.EntityFrameworkCore;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Repositories
{
    public class ProductPriceRepository : Repository, IProductPriceRepository
    {
        public ProductPriceRepository(AccessoriesDbContext context) : base(context)
        {
        }

        public async Task CreateAsync(ProductPriceMap request)
        {
            _context.Add(request);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(ProductPriceMap request)
        {
            var model = await _context.Set<ProductPriceMap>()
                .Where(w => w.ProductPriceMapId == request.ProductPriceMapId)
                .FirstOrDefaultAsync();
            model.FromQty = request.FromQty;
            model.ToQty = request.ToQty;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int productPriceMapId)
        {
            var model = await GetByIdAsync(productPriceMapId);
            model.IsActive = false;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductPriceMap>> GetAllAsync(int productId)
        {
            return await _context.Set<ProductPriceMap>()
                .Where(w=>w.ProductId == productId)
                .ToListAsync();
        }

        public async Task<ProductPriceMap> GetByIdAsync(int productPriceMapId)
        {
            return await _context.Set<ProductPriceMap>()
                .Where(w => w.ProductPriceMapId == productPriceMapId)
                .FirstOrDefaultAsync();
        }

        public async Task<ProductPriceMap> GetByQuantityAsync(int from, int to)
        {
            return await _context.Set<ProductPriceMap>()
                .Where(w => w.FromQty == from && w.ToQty == to)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductPriceMap>> GetByPagingAsync(GetPagedSearch request)
        {
            return await _context.Set<ProductPriceMap>()
                .ToListAsync();
        }


    }
}
