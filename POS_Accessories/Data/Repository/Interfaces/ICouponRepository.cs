using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Interfaces
{
    public interface ICouponRepository: IRepository
    {
        Task<IEnumerable<string>> CreateCouponAsync(Coupon request);
        Task<IEnumerable<string>> UpdateCouponAsync(Coupon request);
        Task<IEnumerable<string>> DeleteCouponAsync(int CouponId);
        Task<Coupon> GetCouponAsync(int CouponId);
        Task<IEnumerable<Coupon>> GetAllCouponsAsync();
        Task<IEnumerable<Coupon>> GetPagedCouponsAsync(GetPagedSearch request);
    }
}
