using POS_Accessories.Business.Interfaces;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;
using POS_Accessories.Models.Response;
using POS_Accessories.Business.Helper;
using System.Net;
using POS_Accessories.Data.Repository.Repositories;

namespace POS_Accessories.Business.Services
{
    public class StockInventoryService : IStockInventoryService
    {
        private readonly IStockInventoryRepository _stockInventoryRepository;

        public StockInventoryService(IStockInventoryRepository stockRepository)
        {
            _stockInventoryRepository = stockRepository;
        }
        public async Task<CommonResponse> CreateAsync(StockInventory request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                request.Status = "A";
                request.CreatedDate = DateTime.Now;
                await _stockInventoryRepository.CreateAsync(request);
                response = Utility.CreateResponse("Created successfully", HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }
        public async Task<CommonResponse> UpdateAsync(StockInventory request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                await _stockInventoryRepository.UpdateAsync(request);
                response = Utility.CreateResponse("Updated successfully", HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }
        public async Task<CommonResponse> UpdateStatusAsync(int stockId, string status)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                await _stockInventoryRepository.UpdateStatusAsync(stockId, status);
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
                var result = await _stockInventoryRepository.GetAllAsync();
                response = Utility.CreateResponse(result, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }
        public async Task<CommonResponse> GetByIdAsync(int stockId)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _stockInventoryRepository.GetByIdAsync(stockId);
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
                pageResult.Results = await _stockInventoryRepository.GetByPagingAsync(request);
                pageResult.TotalRecords = await _stockInventoryRepository.GetTotalCountAsync(request);

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
