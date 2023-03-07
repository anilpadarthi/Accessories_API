using Microsoft.EntityFrameworkCore;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Repositories
{
    public class ConfigurationRepository : Repository, IConfigurationRepository
    {
        public ConfigurationRepository(AccessoriesDbContext context) : base(context)
        {
        }

        public async Task CreateAsync(Configuration request)
        {
            _context.Add(request);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Configuration request)
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int id, string status)
        {
            var dbRecord = await GetByIdAsync(id);
            dbRecord.Status = status;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Configuration>> GetAllActiveConfigurationListAsync()
        {
            var resultList = await _context.Set<Configuration>().Where(w => w.IsActive == true).ToListAsync();
            return resultList;
        }

        public async Task<Configuration> GetByIdAsync(int id)
        {
            var result = await _context.Set<Configuration>().Where(w => w.ConfigId == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Configuration> ValidateUnique(Configuration request)
        {
            return await _context.Set<Configuration>()
                .Where(w => w.ConfigurationTypeId == request.ConfigurationTypeId && w.IsActive == true)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Configuration>> GetByPagingAsync(GetPagedSearch request)
        {
            var query = _context.Set<Configuration>().Where(w => w.Status != "D");

            var result = await query
                .OrderBy(o => o.ConfigurationTypeId)
                .Skip((request.pageNo - 1) * request.pageSize)
                .Take(request.pageSize)
                .ToListAsync();

            return result;
        }

        public async Task<int> GetTotalCountAsync(GetPagedSearch request)
        {
            var query = _context.Set<Configuration>().Where(w => w.Status != "D");
            return await query.CountAsync();
        }

    }
}
