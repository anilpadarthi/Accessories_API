using POS_Accessories.Business.Interfaces;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Business.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationRepository _configurationRepository;

        public ConfigurationService(IConfigurationRepository ConfigurationRepository)
        {
            _configurationRepository = ConfigurationRepository;
        }
        public async Task<IEnumerable<string>> CreateConfigurationAsync(Configuration request)
        {
            return await _configurationRepository.CreateConfigurationAsync(request);
        }

        public async Task<IEnumerable<string>> DeleteConfigurationAsync(int ConfigurationId)
        {
            return await _configurationRepository.DeleteConfigurationAsync(ConfigurationId);
        }

        public async Task<IEnumerable<string>> UpdateConfigurationAsync(Configuration request)
        {
            var configuration = await _configurationRepository.GetConfigurationAsync(request.ConfigId);
            configuration.ConfigType = request.ConfigType;
            configuration.Amount = request.Amount;
            configuration.FromDate = request.FromDate;
            configuration.ToDate = request.ToDate;
            configuration.ModifiedBy = request.ModifiedBy;
            return await _configurationRepository.UpdateConfigurationAsync(configuration);            
        }

        public async Task<IEnumerable<Configuration>> GetAllConfigurationsAsync()
        {
            return await _configurationRepository.GetAllConfigurationsAsync();
        }

        public async Task<Configuration> GetConfigurationAsync(int ConfigurationId)
        {
            return await _configurationRepository.GetConfigurationAsync(ConfigurationId);
        }

        public async Task<IEnumerable<Configuration>> GetPagedConfigurationsAsync(GetPagedRequest request)
        {
            return await _configurationRepository.GetPagedConfigurationsAsync(request);
        }
    }
}
