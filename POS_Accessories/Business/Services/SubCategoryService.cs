using POS_Accessories.Business.Helper;
using POS_Accessories.Business.Interfaces;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;
using POS_Accessories.Models.Response;
using System.Net;

namespace POS_Accessories.Business.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<CommonResponse> CreateAsync(SubCategory request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _subCategoryRepository.GetByNameAsync(request.SubCategoryName);
                if (result != null)
                {
                    response = Utility.CreateResponse("Name already exist", HttpStatusCode.Conflict);
                }
                else
                {
                    request.Status = "A";
                    await _subCategoryRepository.CreateAsync(request);
                    response = Utility.CreateResponse("Created successfully", HttpStatusCode.Created);
                }
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }
        public async Task<CommonResponse> UpdateAsync(SubCategory request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _subCategoryRepository.GetByNameAsync(request.SubCategoryName);
                if (result != null && result.SubCategoryId != request.SubCategoryId)
                {
                    response = Utility.CreateResponse("Name already exist", HttpStatusCode.Conflict);
                }
                else
                {
                    await _subCategoryRepository.UpdateAsync(request);
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
                await _subCategoryRepository.UpdateStatusAsync(id, status);
                response = Utility.CreateResponse("Updated successfully", HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }
        public async Task<CommonResponse> GetAllAsync(int categoryId)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _subCategoryRepository.GetAllAsync(categoryId);
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
                var result = await _subCategoryRepository.GetByIdAsync(id);
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
                var result = await _subCategoryRepository.GetByPagingAsync(request);
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
