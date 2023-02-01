using POS_Accessories.Business.Helper;
using POS_Accessories.Business.Interfaces;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;
using POS_Accessories.Models.Response;
using System.Net;

namespace POS_Accessories.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<CommonResponse> CreateAsync(Category request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _categoryRepository.GetByNameAsync(request.CategoryName);
                if (result != null)
                {
                    response = Utility.CreateResponse("Name already exist", HttpStatusCode.Conflict);
                }
                else
                {
                    request.Status = "A";
                    await _categoryRepository.CreateAsync(request);
                    response = Utility.CreateResponse("Created successfully", HttpStatusCode.Created);
                }
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }
        public async Task<CommonResponse> UpdateAsync(Category request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _categoryRepository.GetByNameAsync(request.CategoryName);
                if (result != null && result.CategoryId != request.CategoryId)
                {
                    response = Utility.CreateResponse("Name already exist", HttpStatusCode.Conflict);
                }
                else
                {
                    await _categoryRepository.UpdateAsync(request);
                    response = Utility.CreateResponse("Updated successfully", HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }
        public async Task<CommonResponse> UpdateStatusAsync(int categoryId, string status)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                await _categoryRepository.UpdateStatusAsync(categoryId, status);
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
                var result = await _categoryRepository.GetAllAsync();
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
                var result = await _categoryRepository.GetByIdAsync(categoryId);
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
                pageResult.Results = await _categoryRepository.GetByPagingAsync(request);
                pageResult.TotalRecords = await _categoryRepository.GetTotalCountAsync(request);

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
