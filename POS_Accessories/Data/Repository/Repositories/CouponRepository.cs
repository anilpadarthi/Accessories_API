using Microsoft.EntityFrameworkCore;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Repositories
{
    public class CouponRepository : Repository, ICouponRepository
    {
        public CouponRepository(AccessoriesDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<string>> CreateCouponAsync(Coupon request)
        {
            _context.Add(request);
            await _context.SaveChangesAsync();
            List<string> resultList = new List<string>();
            resultList.Add("Created successfully");
            return resultList;
        }

        public async Task<IEnumerable<string>> DeleteCouponAsync(int CouponId)
        {
            var Coupon = await GetCouponAsync(CouponId);
            Coupon.IsActive = false;
            await _context.SaveChangesAsync();
            List<string> resultList = new List<string>();
            resultList.Add("Deleted successfully");
            return resultList;
        }

        public async Task<IEnumerable<string>> UpdateCouponAsync(Coupon request)
        {
            //var Coupon = await GetCouponAsync(request.CouponId);
            //Coupon.CouponName = request.CouponName;
            await _context.SaveChangesAsync();
            List<string> resultList = new List<string>();
            resultList.Add("Updated successfully");
            return resultList;
        }

        public async Task<IEnumerable<Coupon>> GetAllCouponsAsync()
        {
            var resultList = await _context.Set<Coupon>().ToListAsync();
            return resultList;
        }

        public async Task<Coupon> GetCouponAsync(int CouponId)
        {
            var result = await _context.Set<Coupon>().Where(w => w.CouponId == CouponId).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<Coupon>> GetPagedCouponsAsync(GetPagedRequest request)
        {
            var resultList = await _context.Set<Coupon>().ToListAsync();
            return resultList;
        }


    }
}
