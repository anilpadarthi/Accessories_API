using POS_Accessories.Business.Helper;
using POS_Accessories.Business.Interfaces;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;
using POS_Accessories.Models.Response;
using System.Net;

namespace POS_Accessories.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository ProductRepository)
        {
            _productRepository = ProductRepository;
        }
        public async Task<CommonResponse> CreateAsync(Product request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _productRepository.GetByNameAsync(request.ProductName);
                if (result != null)
                {
                    response = Utility.CreateResponse("Name already exist", HttpStatusCode.Conflict);
                }
                else
                {
                    request.Status = "A";
                    await _productRepository.CreateAsync(request);
                    response = Utility.CreateResponse("Created successfully", HttpStatusCode.Created);
                }
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }

        public async Task<CommonResponse> UpdateAsync(Product request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _productRepository.GetByNameAsync(request.ProductName);
                if (result != null && result.ProductId != request.ProductId)
                {
                    response = Utility.CreateResponse("Name already exist", HttpStatusCode.Conflict);
                }
                else
                {
                    await _productRepository.UpdateAsync(request);
                    response = Utility.CreateResponse("Updated successfully", HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }

        public async Task<CommonResponse> UpdateStatusAsync(int id, string status)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                await _productRepository.UpdateStatusAsync(id, status);
                response = Utility.CreateResponse("Updated successfully", HttpStatusCode.OK);
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
                var result = await _productRepository.GetAllAsync();
                response = Utility.CreateResponse(result, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }

        public async Task<CommonResponse> GetByIdAsync(int id)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _productRepository.GetByIdAsync(id);
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
                var result = await _productRepository.GetByPagingAsync(request);
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
