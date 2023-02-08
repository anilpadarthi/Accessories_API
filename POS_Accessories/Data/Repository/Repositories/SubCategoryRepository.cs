using Microsoft.EntityFrameworkCore;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Repositories
{
    public class SubCategoryRepository : Repository, ISubCategoryRepository
    {
        public SubCategoryRepository(AccessoriesDbContext context) : base(context)
        {
        }

        public async Task CreateAsync(SubCategory request)
        {
            _context.Add(request);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(SubCategory request)
        {
            var dbRecord = await _context.Set<SubCategory>()
                .Where(w => w.SubCategoryId == request.SubCategoryId)
                .FirstOrDefaultAsync();

            dbRecord.SubCategoryName = request.SubCategoryName;
            dbRecord.Image = request.Image;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int id, string status)
        {
            var dbRecord = await GetByIdAsync(id);
            dbRecord.Status = status;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SubCategory>> GetAllAsync(int categoryId)
        {
            return await _context.Set<SubCategory>()
                .Where(cat => cat.Status != "D" && cat.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<SubCategory> GetByIdAsync(int subCategoryId)
        {
            return await _context.Set<SubCategory>()
                .Where(w => w.SubCategoryId == subCategoryId)
                .FirstOrDefaultAsync();
        }

        public async Task<SubCategory> GetByNameAsync(string subCategoryName, int? categoryId)
        {
            return await _context.Set<SubCategory>()
                .Where(w => w.SubCategoryName.ToUpper() == subCategoryName.ToUpper() && w.CategoryId == categoryId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SubCategory>> GetByPagingAsync(GetPagedSearch request)
        {
            var query = _context.Set<SubCategory>()
                .Where(w => w.Status != "D");

            if (request.categoryId.HasValue && request.categoryId > 0)
            {
                query = query.Where(w => w.CategoryId == request.categoryId);
            }

            if (!string.IsNullOrEmpty(request.searchText))
            {
                query = query.Where(w => w.SubCategoryName.Contains(request.searchText));
            }

            var result = await query
                .OrderBy(o => o.SubCategoryName)
                .Skip((request.pageNo - 1) * request.pageSize)
                .Take(request.pageSize)
                .ToListAsync();

            return result;
        }

        public async Task<int> GetTotalCountAsync(GetPagedSearch request)
        {
            var query = _context.Set<SubCategory>()
               .Where(w => w.Status != "D");

            if (request.categoryId.HasValue && request.categoryId > 0)
            {
                query = query.Where(w => w.CategoryId == request.categoryId);
            }

            if (!string.IsNullOrEmpty(request.searchText))
            {
                query = query.Where(w => w.SubCategoryName.Contains(request.searchText));
            }
            return await query.CountAsync();
        }

    }
}
