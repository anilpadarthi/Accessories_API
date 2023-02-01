using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Interfaces
{
    public interface IProductPriceRepository : IRepository
    {
        Task CreateAsync(ProductPriceMap request);
        Task UpdateAsync(ProductPriceMap request);
        Task DeleteAsync(int productPriceMapId);
        Task<ProductPriceMap> GetByIdAsync(int productPriceMapId);
        Task<ProductPriceMap> GetByQuantityAsync(int from, int to);
        Task<IEnumerable<ProductPriceMap>> GetAllAsync(int productId);
        Task<IEnumerable<ProductPriceMap>> GetByPagingAsync(GetPagedSearch request);
    }
}
