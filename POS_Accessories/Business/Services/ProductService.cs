using AutoMapper;
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
        private readonly IProductPriceRepository _productPriceRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IProductPriceRepository productPriceRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _productPriceRepository = productPriceRepository;
            _mapper = mapper;
        }
        public async Task<CommonResponse> CreateAsync(ProductRequestModel request)
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
                    var createCriteria = _mapper.Map<Product>(request);
                    createCriteria.Status = "A";
                    await _productRepository.CreateAsync(createCriteria);

                    if (request.PriceList != null)
                    {
                        foreach (var item in request.PriceList)
                        {
                            var createPrice = _mapper.Map<ProductPriceMap>(item);
                            _productRepository.Add(createPrice);
                            _productRepository.SaveChangesAsync();
                        }
                    }

                    //if (request.ProductImageMaps != null)
                    //{
                    //    foreach (var item in request.ProductImageMaps)
                    //    {
                    //        _productRepository.Add(item);
                    //        _productRepository.SaveChangesAsync();
                    //    }
                    //}

                    response = Utility.CreateResponse("Created successfully", HttpStatusCode.Created);
                }
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }

        public async Task<CommonResponse> UpdateAsync(ProductRequestModel request)
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
                    var updateCriteria = _mapper.Map<Product>(request);
                    await _productRepository.UpdateAsync(updateCriteria
                        );
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
                PagedResult pageResult = new PagedResult();
                pageResult.Results = await _productRepository.GetByPagingAsync(request);
                pageResult.TotalRecords = await _productRepository.GetTotalCountAsync(request);

                response = Utility.CreateResponse(pageResult, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }

    }
}
