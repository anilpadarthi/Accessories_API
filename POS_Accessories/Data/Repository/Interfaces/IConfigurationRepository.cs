using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Interfaces
{
    public interface IConfigurationRepository: IRepository
    {

        Task CreateAsync(Configuration request);
        Task UpdateAsync(Configuration request);
        Task UpdateStatusAsync(int id, string status);
        Task<Configuration> GetByIdAsync(int id);
        Task<Configuration> ValidateUnique(Configuration request);
        Task<IEnumerable<Configuration>> GetAllActiveConfigurationListAsync();
        Task<IEnumerable<Configuration>> GetByPagingAsync(GetPagedSearch request);
        Task<int> GetTotalCountAsync(GetPagedSearch request);

    }
}
