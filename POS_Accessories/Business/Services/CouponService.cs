using POS_Accessories.Business.Interfaces;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;
using POS_Accessories.Models.Response;
using POS_Accessories.Business.Helper;
using System.Net;

namespace POS_Accessories.Business.Services
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository _couponRepository;

        public CouponService(ICouponRepository CouponRepository)
        {
            _couponRepository = CouponRepository;
        }
        public async Task<CommonResponse> CreateAsync(CouponRequestModel request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _couponRepository.GetByNameAsync(request.CouponCode);
                if (result != null)
                {
                    response = Utility.CreateResponse("Code is already exist", HttpStatusCode.Conflict);
                }
                else
                {
                    Coupon couponModel = new Coupon();
                    couponModel.Status = "A";
                    couponModel.CouponCode = request.CouponCode;
                    couponModel.Description = request.Description;
                    couponModel.ValidFrom = Convert.ToDateTime(request.ValidFrom);
                    couponModel.ValidTo = Convert.ToDateTime(request.ValidTo);

                    await _couponRepository.CreateAsync(couponModel);
                    response = Utility.CreateResponse("Created successfully", HttpStatusCode.Created);
                }
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }
        public async Task<CommonResponse> UpdateAsync(CouponRequestModel request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _couponRepository.GetByNameAsync(request.CouponCode);
                if (result != null && result.CouponId != request.CouponId)
                {
                    response = Utility.CreateResponse("Name already exist", HttpStatusCode.Conflict);
                }
                else
                {
                    Coupon couponModel = await _couponRepository.GetByIdAsync(request.CouponId);
                    couponModel.CouponId = request.CouponId;
                    couponModel.Status = "A";
                    couponModel.CouponCode = request.CouponCode;
                    couponModel.Description = request.Description;
                    couponModel.ValidFrom = Convert.ToDateTime(request.ValidFrom);
                    couponModel.ValidTo = Convert.ToDateTime(request.ValidTo);
                    await _couponRepository.UpdateAsync(couponModel);
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
                await _couponRepository.UpdateStatusAsync(id, status);
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
                var result = await _couponRepository.GetAllAsync();
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
                var result = await _couponRepository.GetByIdAsync(id);
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
                pageResult.Results = await _couponRepository.GetByPagingAsync(request);
                pageResult.TotalRecords = await _couponRepository.GetTotalCountAsync(request);

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
