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

        public async Task<IEnumerable<string>> CreateSubCategoryAsync(SubCategory request)
        {
            _context.Add(request);
            await _context.SaveChangesAsync();
            List<string> resultList = new List<string>();
            resultList.Add("Created successfully");
            return resultList;
        }

        public async Task<IEnumerable<string>> DeleteSubCategoryAsync(int categoryId)
        {
            var category = await GetSubCategoryAsync(categoryId);
            category.Status = "D";
            await _context.SaveChangesAsync();
            List<string> resultList = new List<string>();
            resultList.Add("Deleted successfully");
            return resultList;
        }

        public async Task<IEnumerable<string>> UpdateSubCategoryAsync(SubCategory request)
        {
            //var subCategory = await GetSubCategoryAsync(request.SubCategoryId);
            //subCategory.SubCategoryName = request.SubCategoryName;
            await _context.SaveChangesAsync();
            List<string> resultList = new List<string>();
            resultList.Add("Updated successfully");
            return resultList;
        }

        public async Task<IEnumerable<SubCategory>> GetAllSubCategoriesAsync()
        {
            var resultList = await _context.Set<SubCategory>().ToListAsync();
            return resultList;
        }

        public async Task<SubCategory> GetSubCategoryAsync(int categoryId)
        {
            var result = await _context.Set<SubCategory>().Where(w => w.CategoryId == categoryId).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<SubCategory>> GetPagedSubCategoriesAsync(GetPagedRequest request)
        {
            var resultList = await _context.Set<SubCategory>().ToListAsync();
            return resultList;
        }


    }
}
