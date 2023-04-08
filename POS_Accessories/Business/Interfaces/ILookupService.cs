using POS_Accessories.Models.Response;

namespace POS_Accessories.Business.Interfaces
{
    public interface ILookupService
    {
        Task<CommonResponse> GetCategories();
        Task<CommonResponse> GetSubCategories(int categoryId);
        Task<CommonResponse> GetAvailableColours();
        Task<CommonResponse> GetAvailableSizes();
        Task<CommonResponse> GetConfigurationTypes();
        Task<CommonResponse> GetProducts();
        Task<CommonResponse> GetSuppliers();
        Task<CommonResponse> GetOrderStatusTypes();
        Task<CommonResponse> GetOrderPaymentTypes();
        Task<CommonResponse> GetOrderDeliveryTypes();
        Task<CommonResponse> GetAreas();
        Task<CommonResponse> GetShops(int areaId);
        Task<CommonResponse> GetAgents();
        Task<CommonResponse> GetManagers();
    }
}
