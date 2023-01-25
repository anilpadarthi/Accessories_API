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

        public async Task CreateCategoryAsync(Category request)
        {
            _context.Add(request);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<string>> DeleteCategoryAsync(int categoryId)
        {
            var category = await GetCategoryAsync(categoryId);
            category.Status = "D";
            await _context.SaveChangesAsync();
            List<string> resultList = new List<string>();
            resultList.Add("Deleted successfully");
            return resultList;
        }

        public async Task UpdateCategoryAsync(Category request)
        {
            var category = await _context.Set<Category>().Where(w => w.CategoryId == request.CategoryId).FirstOrDefaultAsync();
            category.CategoryName = request.CategoryName;
            category.Image = request.Image;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            var resultList = await _context.Set<Category>().ToListAsync();
            return resultList;
        }

        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            return await _context.Set<Category>()
                .Where(w => w.CategoryId == categoryId)
                .FirstOrDefaultAsync();
        }

        public async Task<Category> GetCategoryByNameAsync(string categoryName)
        {
            return await _context.Set<Category>()
                .Where(w => w.CategoryName.ToUpper() == categoryName.ToUpper())
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetPagedCategories(GetPagedRequest request)
        {
            var resultList = await _context.Set<Category>().ToListAsync();
            return resultList;
        }


    }
}
