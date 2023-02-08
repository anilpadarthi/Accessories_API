using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Interfaces
{
    public interface ICouponRepository: IRepository
    {
        Task CreateAsync(Coupon request);
        Task UpdateAsync(Coupon request);
        Task UpdateStatusAsync(int id, string status);
        Task<Coupon> GetByIdAsync(int id);
        Task<Coupon> GetByNameAsync(string name);
        Task<IEnumerable<Coupon>> GetAllAsync();
        Task<IEnumerable<Coupon>> GetByPagingAsync(GetPagedSearch request);
        Task<int> GetTotalCountAsync(GetPagedSearch request);
    }
}
