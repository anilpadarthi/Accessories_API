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

        public async Task<IEnumerable<LookupResult>> GetSuppliers()
        {
            var resultList = await _context.Set<Supplier>()
                             .Select(x => new LookupResult
                             {
                                 Id = x.SupplierId,
                                 Name = x.SupplierName
                             }).ToListAsync();

            return resultList;
        }

        public async Task<IEnumerable<LookupResult>> GetOrderStatusTypes()
        {
            var resultList = await _context.Set<OrderStatusType>()
                             .Select(x => new LookupResult
                             {
                                 Id = x.OrderStatusTypeId,
                                 Name = x.Name
                             }).ToListAsync();

            return resultList;
        }

        public async Task<IEnumerable<LookupResult>> GetOrderPaymentTypes()
        {
            var resultList = await _context.Set<OrderPaymentType>()
                             .Select(x => new LookupResult
                             {
                                 Id = x.OrderPaymentTypeId,
                                 Name = x.Name
                             }).ToListAsync();

            return resultList;
        }

        public async Task<IEnumerable<LookupResult>> GetOrderDeliveryTypes()
        {
            var resultList = await _context.Set<OrderDeliveryType>()
                             .Select(x => new LookupResult
                             {
                                 Id = x.OrderDeliveryTypeId,
                                 Name = x.Name
                             }).ToListAsync();

            return resultList;
        }

        public async Task<IEnumerable<LookupResult>> GetAreas()
        {
            var resultList = await _context.Set<Area>()
                             .Select(x => new LookupResult
                             {
                                 Id = x.AreaId,
                                 Name = x.AreaName
                             }).ToListAsync();

            return resultList;
        }

        public async Task<IEnumerable<LookupResult>> GetShops(int areaId)
        {
            var resultList = await _context.Set<Shop>()
                             .Select(x => new LookupResult
                             {
                                 Id = x.ShopId,
                                 Name = x.ShopName
                             }).ToListAsync();

            return resultList;
        }


        public async Task<IEnumerable<LookupResult>> GetAgents()
        {
            var resultList = await _context.Set<User>()
                             .Where(w => w.RoleId == 4)
                             .Select(x => new LookupResult
                             {
                                 Id = x.UserId,
                                 Name = x.UserName
                             }).ToListAsync();

            return resultList;
        }


        public async Task<IEnumerable<LookupResult>> GetManagers()
        {
            var resultList = await _context.Set<User>()
                             .Where(w => w.RoleId == 3)
                             .Select(x => new LookupResult
                             {
                                 Id = x.UserId,
                                 Name = x.UserName
                             }).ToListAsync();

            return resultList;
        }


    }
}
