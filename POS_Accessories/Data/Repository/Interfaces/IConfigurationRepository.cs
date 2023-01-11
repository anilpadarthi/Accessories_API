using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Interfaces
{
    public interface IConfigurationRepository: IRepository
    {
        Task<IEnumerable<string>> CreateConfigurationAsync(Configuration request);
        Task<IEnumerable<string>> UpdateConfigurationAsync(Configuration request);
        Task<IEnumerable<string>> DeleteConfigurationAsync(int ConfigurationId);
        Task<Configuration> GetConfigurationAsync(int ConfigurationId);
        Task<IEnumerable<Configuration>> GetAllConfigurationsAsync();
        Task<IEnumerable<Configuration>> GetPagedConfigurationsAsync(GetPagedRequest request);
    }
}
