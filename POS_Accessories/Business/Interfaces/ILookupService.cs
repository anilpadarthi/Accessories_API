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
    }
}
