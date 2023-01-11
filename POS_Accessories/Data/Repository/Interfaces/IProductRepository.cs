using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Interfaces
{
    public interface IProductRepository: IRepository
    {
        Task<Product> GetProductAsync(int ProductId);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<IEnumerable<Product>> GetPagedProductsAsync(GetPagedRequest request);
    }
}
