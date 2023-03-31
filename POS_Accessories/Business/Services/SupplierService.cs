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
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _SupplierRepository;
        private readonly IMapper _mapper;

        public SupplierService(ISupplierRepository SupplierRepository, IMapper mapper)
        {
            _SupplierRepository = SupplierRepository;
            _mapper = mapper;
        }
        public async Task<CommonResponse> CreateAsync(SupplierRequestModel request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _SupplierRepository.GetByNameAsync(request.SupplierName);
                if (result != null)
                {
                    response = Utility.CreateResponse("Name already exist", HttpStatusCode.Conflict);
                }
                else
                {
                    Supplier supplierModel = new Supplier();
                    supplierModel.SupplierName = request.SupplierName;
                    supplierModel.Status = "A";
                    supplierModel.CreatedBy = 1;
                    supplierModel.CreatedDate = DateTime.Now;
                    await _SupplierRepository.CreateAsync(supplierModel);
                    response = Utility.CreateResponse("Created successfully", HttpStatusCode.Created);
                }
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }
        public async Task<CommonResponse> UpdateAsync(SupplierRequestModel request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var supplierModel = await _SupplierRepository.GetByNameAsync(request.SupplierName);
                if (supplierModel != null && supplierModel.SupplierId != request.SupplierId)
                {
                    response = Utility.CreateResponse("Name already exist", HttpStatusCode.Conflict);
                }
                else
                {
                    supplierModel.SupplierName = request.SupplierName;
                    supplierModel.ModifiedBy = 1;
                    supplierModel.ModifiedDate = DateTime.Now;
                    await _SupplierRepository.UpdateAsync(supplierModel);
                    response = Utility.CreateResponse("Updated successfully", HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }
        public async Task<CommonResponse> UpdateStatusAsync(int SupplierId, string status)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                await _SupplierRepository.UpdateStatusAsync(SupplierId, status);
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
                var result = await _SupplierRepository.GetAllAsync();
                response = Utility.CreateResponse(result, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }
        public async Task<CommonResponse> GetByIdAsync(int SupplierId)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _SupplierRepository.GetByIdAsync(SupplierId);
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
                pageResult.Results = await _SupplierRepository.GetByPagingAsync(request);
                pageResult.TotalRecords = await _SupplierRepository.GetTotalCountAsync(request);

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
