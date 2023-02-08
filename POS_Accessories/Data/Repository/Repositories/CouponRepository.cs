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

        public async Task CreateAsync(Coupon request)
        {
            _context.Add(request);
            await _context.SaveChangesAsync();
        }        

        public async Task UpdateAsync(Coupon request)
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int id, string status)
        {
            var dbRecord = await GetByIdAsync(id);
            dbRecord.Status = status;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Coupon>> GetAllAsync()
        {
            var resultList = await _context.Set<Coupon>().ToListAsync();
            return resultList;
        }

        public async Task<Coupon> GetByIdAsync(int id)
        {
            var result = await _context.Set<Coupon>().Where(w => w.CouponId == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Coupon> GetByNameAsync(string name)
        {
            return await _context.Set<Coupon>()
                .Where(w => w.CouponCode.ToUpper() == name.ToUpper())
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Coupon>> GetByPagingAsync(GetPagedSearch request)
        {
            var query = _context.Set<Coupon>()
                .Where(w => w.Status != "D");

            if (!string.IsNullOrEmpty(request.searchText))
            {
                query = query.Where(w => w.CouponCode.Contains(request.searchText));
            }

            var result = await query
                .OrderBy(o => o.CouponCode)
                .Skip((request.pageNo - 1) * request.pageSize)
                .Take(request.pageSize)
                .ToListAsync();

            return result;
        }

        public async Task<int> GetTotalCountAsync(GetPagedSearch request)
        {
            var query = _context.Set<Coupon>()
               .Where(w => w.Status != "D");

            if (!string.IsNullOrEmpty(request.searchText))
            {
                query = query.Where(w => w.CouponCode.Contains(request.searchText));
            }
            return await query.CountAsync();
        }


    }
}
