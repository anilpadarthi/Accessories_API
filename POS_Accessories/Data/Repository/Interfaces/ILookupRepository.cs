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
        Task<IEnumerable<LookupResult>> GetProducts();
        Task<IEnumerable<LookupResult>> GetSuppliers();
        Task<IEnumerable<LookupResult>> GetOrderStatusTypes();
        Task<IEnumerable<LookupResult>> GetOrderPaymentTypes();
        Task<IEnumerable<LookupResult>> GetOrderDeliveryTypes();
        Task<IEnumerable<LookupResult>> GetAreas();
        Task<IEnumerable<LookupResult>> GetShops(int areaId);
        Task<IEnumerable<LookupResult>> GetAgents();
        Task<IEnumerable<LookupResult>> GetManagers();
    }
}
