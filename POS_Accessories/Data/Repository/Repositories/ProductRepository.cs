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

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var resultList = await _context.Set<Product>().ToListAsync();
            return resultList;
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

        public async Task<IEnumerable<Product>> GetPagedProductsAsync(GetPagedRequest request)
        {
            var resultList = await _context.Set<Product>().ToListAsync();
            return resultList;
        }


    }
}
