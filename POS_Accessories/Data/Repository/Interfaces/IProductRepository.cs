using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Interfaces
{
    public interface IProductRepository: IRepository
    {
        Task CreateAsync(Product request);
        Task UpdateAsync(Product request);
        Task UpdateStatusAsync(int id, string status);
        Task<Product> GetByIdAsync(int productId);
        Task<Product> GetByNameAsync(string productName);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> GetByPagingAsync(GetPagedSearch request);
    }
}
