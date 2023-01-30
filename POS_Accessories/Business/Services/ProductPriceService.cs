using POS_Accessories.Business.Helper;
using POS_Accessories.Business.Interfaces;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;
using POS_Accessories.Models.Response;
using System.Net;

namespace POS_Accessories.Business.Services
{
    public class ProductPriceService : IProductPriceService
    {
        private readonly IProductPriceRepository _productPriceRepository;

        public ProductPriceService(IProductPriceRepository productPriceRepository)
        {
            _productPriceRepository = productPriceRepository;
        }
        public async Task<CommonResponse> CreateAsync(ProductPriceMap request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _productPriceRepository.GetByQuantityAsync(request.FromQty, request.ToQty ?? 0);
                if (result != null)
                {
                    response = Utility.CreateResponse("Already exist", HttpStatusCode.Conflict);
                }
                else
                {
                    await _productPriceRepository.CreateAsync(request);
                    response = Utility.CreateResponse("Created successfully", HttpStatusCode.Created);
                }
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }
        public async Task<CommonResponse> UpdateAsync(ProductPriceMap request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _productPriceRepository.GetByQuantityAsync(request.FromQty, request.ToQty ?? 0);
                if (result != null)
                {
                    response = Utility.CreateResponse("Already exist", HttpStatusCode.Conflict);
                }
                else
                {
                    await _productPriceRepository.UpdateAsync(request);
                    response = Utility.CreateResponse("Updated successfully", HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }
        public async Task<CommonResponse> DeleteAsync(int productPriceMapId)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                await _productPriceRepository.DeleteAsync(productPriceMapId);
                response = Utility.CreateResponse("Deleted successfully", HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }
        public async Task<CommonResponse> GetAllAsync(int productId)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _productPriceRepository.GetAllAsync(productId);
                response = Utility.CreateResponse(result, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }
        public async Task<CommonResponse> GetByIdAsync(int productPriceMapId)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _productPriceRepository.GetByIdAsync(productPriceMapId);
                response = Utility.CreateResponse(result, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }
        public async Task<CommonResponse> GetByPagingAsync(GetPagedRequest request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _productPriceRepository.GetByPagingAsync(request);
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
