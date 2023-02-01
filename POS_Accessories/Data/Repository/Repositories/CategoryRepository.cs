using Microsoft.EntityFrameworkCore;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Repositories
{
    public class CategoryRepository : Repository, ICategoryRepository
    {
        public CategoryRepository(AccessoriesDbContext context) : base(context)
        {
        }

        public async Task CreateAsync(Category request)
        {
            _context.Add(request);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Category request)
        {
            var dbRecord = await _context.Set<Category>()
                .Where(w => w.CategoryId == request.CategoryId)
                .FirstOrDefaultAsync();
            dbRecord.CategoryName = request.CategoryName;
            dbRecord.Image = request.Image;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int categoryId, string status)
        {
            var dbRecord = await GetByIdAsync(categoryId);
            dbRecord.Status = status;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Set<Category>()
                .Where(w => w.Status != "D")
                .ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int categoryId)
        {
            return await _context.Set<Category>()
                .Where(w => w.CategoryId == categoryId)
                .FirstOrDefaultAsync();
        }

        public async Task<Category> GetByNameAsync(string categoryName)
        {
            return await _context.Set<Category>()
                .Where(w => w.CategoryName.ToUpper() == categoryName.ToUpper())
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetByPagingAsync(GetPagedSearch request)
        {
            var query = _context.Set<Category>()
                .Where(w => w.Status != "D");

            if (!string.IsNullOrEmpty(request.searchText))
            {
                query = query.Where(w => w.CategoryName.Contains(request.searchText));
            }

            var result = await query
                .Skip((request.pageNo - 1) * request.pageSize)
                .Take(request.pageSize)
                .ToListAsync();

            return result;
        }

        public async Task<int> GetTotalCountAsync(GetPagedSearch request)
        {
            var query = _context.Set<Category>()
               .Where(w => w.Status != "D");

            if (!string.IsNullOrEmpty(request.searchText))
            {
                query = query.Where(w => w.CategoryName.Contains(request.searchText));
            }
            return await query.CountAsync();
        }


    }
}
