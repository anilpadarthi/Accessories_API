using POS_Accessories.Models.Response;

namespace POS_Accessories.Data.Repository.Interfaces
{
    public interface ILookupRepository : IRepository
    {
        Task<IEnumerable<LookupResult>> GetCategories();
        Task<IEnumerable<LookupResult>> GetSubCategories(int categoryId);
        Task<IEnumerable<LookupResult>> GetAvailableColours();
        Task<IEnumerable<LookupResult>> GetAvailableSizes();
        Task<IEnumerable<LookupResult>> GetConfigurationTypes();
    }
}
