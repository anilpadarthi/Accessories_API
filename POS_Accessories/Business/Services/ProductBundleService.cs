using POS_Accessories.Business.Helper;
using POS_Accessories.Business.Interfaces;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;
using POS_Accessories.Models.Response;
using System.Net;

namespace POS_Accessories.Business.Services
{
    public class ProductBundleService : IProductBundleService
    {
        private readonly IProductBundleRepository _productBundleRepository;

        public ProductBundleService(IProductBundleRepository productBundleRepository)
        {
            _productBundleRepository = productBundleRepository;
        }
        public async Task<CommonResponse> CreateAsync(ProductBundleMap request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                await _productBundleRepository.CreateAsync(request);
                response = Utility.CreateResponse("Created successfully", HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }
        public async Task<CommonResponse> UpdateAsync(ProductBundleMap request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                await _productBundleRepository.UpdateAsync(request);
                response = Utility.CreateResponse("Updated successfully", HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }
        public async Task<CommonResponse> DeleteAsync(int categoryId)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                await _productBundleRepository.DeleteAsync(categoryId);
                response = Utility.CreateResponse("Deleted successfully", HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }
        public async Task<CommonResponse> GetAllAsync()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _productBundleRepository.GetAllAsync();
                response = Utility.CreateResponse(result, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }
        public async Task<CommonResponse> GetByIdAsync(int categoryId)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _productBundleRepository.GetByIdAsync(categoryId);
                response = Utility.CreateResponse(result, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }
        public async Task<CommonResponse> GetByPagingAsync(GetPagedSearch request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _productBundleRepository.GetByPagingAsync(request);
                response = Utility.CreateResponse(result, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }
    }
}
