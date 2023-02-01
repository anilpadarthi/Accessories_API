using POS_Accessories.Business.Interfaces;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Business.Services
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository _couponRepository;

        public CouponService(ICouponRepository CouponRepository)
        {
            _couponRepository = CouponRepository;
        }
        public async Task<IEnumerable<string>> CreateCouponAsync(Coupon request)
        {
            return await _couponRepository.CreateCouponAsync(request);
        }

        public async Task<IEnumerable<string>> DeleteCouponAsync(int CouponId)
        {
            return await _couponRepository.DeleteCouponAsync(CouponId);
        }

        public async Task<IEnumerable<string>> UpdateCouponAsync(Coupon request)
        {
            var coupon = await _couponRepository.GetCouponAsync(request.CouponId);
            coupon.CouponType = request.CouponType;
            coupon.CouponCode = request.CouponCode;
            coupon.ValidFrom = request.ValidFrom;
            coupon.ValidTo = request.ValidTo;
            coupon.ModifiedBy = request.ModifiedBy;
            return await _couponRepository.UpdateCouponAsync(coupon);            
        }

        public async Task<IEnumerable<Coupon>> GetAllCouponsAsync()
        {
            return await _couponRepository.GetAllCouponsAsync();
        }

        public async Task<Coupon> GetCouponAsync(int CouponId)
        {
            return await _couponRepository.GetCouponAsync(CouponId);
        }

        public async Task<IEnumerable<Coupon>> GetPagedCouponsAsync(GetPagedSearch request)
        {
            return await _couponRepository.GetPagedCouponsAsync(request);
        }
    }
}
