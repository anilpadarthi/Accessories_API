using Microsoft.EntityFrameworkCore;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Repositories
{
    public class SupplierRepository : Repository, ISupplierRepository
    {
        public SupplierRepository(AccessoriesDbContext context) : base(context)
        {
        }

        public async Task CreateAsync(Supplier request)
        {
            _context.Add(request);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Supplier request)
        {
            var dbRecord = await _context.Set<Supplier>()
                .Where(w => w.SupplierId == request.SupplierId)
                .FirstOrDefaultAsync();
            dbRecord.SupplierName = request.SupplierName;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int SupplierId, string status)
        {
            var dbRecord = await GetByIdAsync(SupplierId);
            dbRecord.Status = status;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return await _context.Set<Supplier>()
                .ToListAsync();
        }

        public async Task<Supplier> GetByIdAsync(int SupplierId)
        {
            return await _context.Set<Supplier>()
                .Where(w => w.SupplierId == SupplierId)
                .FirstOrDefaultAsync();
        }

        public async Task<Supplier> GetByNameAsync(string SupplierName)
        {
            return await _context.Set<Supplier>()
                .Where(w => w.SupplierName.ToUpper() == SupplierName.ToUpper())
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Supplier>> GetByPagingAsync(GetPagedSearch request)
        {
            var query = _context.Set<Supplier>()
                .Where(w => w.Status != "D");

            if (!string.IsNullOrEmpty(request.searchText))
            {
                query = query.Where(w => w.SupplierName.Contains(request.searchText));
            }

            var result = await query
                .OrderBy(o => o.SupplierName)
                .Skip((request.pageNo - 1) * request.pageSize)
                .Take(request.pageSize)
                .ToListAsync();

            return result;
        }

        public async Task<int> GetTotalCountAsync(GetPagedSearch request)
        {
            var query = _context.Set<Supplier>().Where(w => w.Status != "D");

            if (!string.IsNullOrEmpty(request.searchText))
            {
                query = query.Where(w => w.SupplierName.Contains(request.searchText));
            }
            return await query.CountAsync();
        }


    }
}
