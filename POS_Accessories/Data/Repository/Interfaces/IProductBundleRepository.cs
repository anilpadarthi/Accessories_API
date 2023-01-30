using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Interfaces
{
    public interface IProductBundleRepository : IRepository
    {
        Task CreateAsync(ProductBundleMap request);
        Task UpdateAsync(ProductBundleMap request);
        Task DeleteAsync(int categoryId);
        Task<ProductBundleMap> GetByIdAsync(int categoryId);
        Task<IEnumerable<ProductBundleMap>> GetAllAsync();
        Task<IEnumerable<ProductBundleMap>> GetByPagingAsync(GetPagedRequest request);
    }
}
