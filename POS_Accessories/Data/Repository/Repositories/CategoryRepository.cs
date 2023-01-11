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

        public async Task<IEnumerable<string>> CreateCategoryAsync(Category request)
        {
            _context.Add(request);
            await _context.SaveChangesAsync();
            List<string> resultList = new List<string>();
            resultList.Add("Created successfully");
            return resultList;
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

        public async Task<IEnumerable<string>> UpdateCategoryAsync(Category request)
        {
            //var category = await GetCategoryAsync(request.CategoryId);
            //category.CategoryName = request.CategoryName;
            await _context.SaveChangesAsync();
            List<string> resultList = new List<string>();
            resultList.Add("Updated successfully");
            return resultList;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            var resultList = await _context.Set<Category>().ToListAsync();
            return resultList;
        }

        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            var result = await _context.Set<Category>().Where(w => w.CategoryId == categoryId).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<Category>> GetPagedCategories(GetPagedRequest request)
        {
            var resultList = await _context.Set<Category>().ToListAsync();
            return resultList;
        }


    }
}
