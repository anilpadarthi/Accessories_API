using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Interfaces
{
    public interface ISupplierRepository : IRepository
    {
        Task CreateAsync(Supplier request);
        Task UpdateAsync(Supplier request);
        Task UpdateStatusAsync(int SupplierId, string status);
        Task<Supplier> GetByIdAsync(int SupplierId);
        Task<Supplier> GetByNameAsync(string SupplierName);
        Task<IEnumerable<Supplier>> GetAllAsync();
        Task<IEnumerable<Supplier>> GetByPagingAsync(GetPagedSearch request);
        Task<int> GetTotalCountAsync(GetPagedSearch request);
    }
}
