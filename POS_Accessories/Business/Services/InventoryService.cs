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
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;

        public InventoryService(IInventoryRepository inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }
        public async Task<CommonResponse> GetWareHouseResultAsync(GetPagedSearch request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                PagedResult pageResult = new PagedResult();
                pageResult.Results = await _inventoryRepository.GetWareHouseResultAsync(request);
                pageResult.TotalRecords = await _inventoryRepository.GetTotalCountAsync(request);

                response = Utility.CreateResponse(pageResult, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }

        public async Task<CommonResponse> GetStockPurchaseHistoyResultAsync(GetPagedSearch request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                PagedResult pageResult = new PagedResult();
                pageResult.Results = await _inventoryRepository.GetStockPurchaseHistoyResultAsync(request);
                pageResult.TotalRecords = await _inventoryRepository.GetTotalCountAsync(request);

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
