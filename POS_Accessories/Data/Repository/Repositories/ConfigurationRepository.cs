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

        public async Task<IEnumerable<string>> CreateConfigurationAsync(Configuration request)
        {
            _context.Add(request);
            await _context.SaveChangesAsync();
            List<string> resultList = new List<string>();
            resultList.Add("Created successfully");
            return resultList;
        }

        public async Task<IEnumerable<string>> DeleteConfigurationAsync(int ConfigurationId)
        {
            var Configuration = await GetConfigurationAsync(ConfigurationId);
            Configuration.IsActive = false;
            await _context.SaveChangesAsync();
            List<string> resultList = new List<string>();
            resultList.Add("Deleted successfully");
            return resultList;
        }

        public async Task<IEnumerable<string>> UpdateConfigurationAsync(Configuration request)
        {
            //var Configuration = await GetConfigurationAsync(request.ConfigurationId);
            //Configuration.ConfigurationName = request.ConfigurationName;
            await _context.SaveChangesAsync();
            List<string> resultList = new List<string>();
            resultList.Add("Updated successfully");
            return resultList;
        }

        public async Task<IEnumerable<Configuration>> GetAllConfigurationsAsync()
        {
            var resultList = await _context.Set<Configuration>().ToListAsync();
            return resultList;
        }

        public async Task<Configuration> GetConfigurationAsync(int ConfigurationId)
        {
            var result = await _context.Set<Configuration>().Where(w => w.ConfigId == ConfigurationId).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<Configuration>> GetPagedConfigurationsAsync(GetPagedSearch request)
        {
            var resultList = await _context.Set<Configuration>().ToListAsync();
            return resultList;
        }


    }
}
