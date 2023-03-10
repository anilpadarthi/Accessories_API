using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Response;
using Microsoft.EntityFrameworkCore;

namespace POS_Accessories.Data.Repository.Repositories
{
    public class LookupRepository : Repository, ILookupRepository
    {
        public LookupRepository(AccessoriesDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<LookupResult>> GetCategories()
        {
            var resultList = await _context.Set<Category>()
                             .Where(w => w.Status != "D")
                             .Select(x => new LookupResult
                             {
                                 Id = x.CategoryId,
                                 Name = x.CategoryName
                             }).ToListAsync();

            return resultList;
        }

        public async Task<IEnumerable<LookupResult>> GetSubCategories(int categoryId)
        {
            var resultList = await _context.Set<SubCategory>()
                             .Where(w => w.CategoryId == categoryId)
                             .Where(w => w.Status != "D")
                             .Select(x => new LookupResult
                             {
                                 Id = x.SubCategoryId,
                                 Name = x.SubCategoryName
                             }).ToListAsync();

            return resultList;
        }

        public async Task<IEnumerable<LookupResult>> GetAvailableColours()
        {
            var resultList = await _context.Set<Colour>()
                             .Select(x => new LookupResult
                             {
                                 Id = x.ColourId,
                                 Name = x.ColourName
                             }).ToListAsync();

            return resultList;
        }

        public async Task<IEnumerable<LookupResult>> GetAvailableSizes()
        {
            var resultList = await _context.Set<Size>()
                             .Select(x => new LookupResult
                             {
                                 Id = x.SizeId,
                                 Name = x.Name
                             }).ToListAsync();

            return resultList;
        }

        public async Task<IEnumerable<LookupResult>> GetConfigurationTypes()
        {
            var resultList = await _context.Set<ConfigurationType>()
                             .Select(x => new LookupResult
                             {
                                 Id = x.ConfigurationTypeId,
                                 Name = x.Name
                             }).ToListAsync();

            return resultList;
        }

        public async Task<IEnumerable<LookupResult>> GetProducts()
        {
            var resultList = await _context.Set<Product>()
                             .Select(x => new LookupResult
                             {
                                 Id = x.ProductId,
                                 Name = x.ProductName
                             }).ToListAsync();

            return resultList;
        }



    }
}
