using Newtonsoft.Json;
using POS_Accessories.Business.Interfaces;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;

namespace POS_Accessories.Business.Services
{
    public class LookupService : ILookupService
    {
        private readonly ILookupRepository _repository;
        public IConfiguration _configuration { get; }
        public LookupService(ILookupRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }
        public async Task<CommonResponse> GetCategories()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var list = await _repository.GetCategories();
                response.data = list;
                response.message = "Success";
                response.statusCode = HttpStatusCode.OK;
                response.status = true;
                response.count = 1;
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }

        public async Task<CommonResponse> GetSubCategories(int categoryId)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var list = await _repository.GetSubCategories(categoryId);
                response.data = list;
                response.message = "Success";
                response.statusCode = HttpStatusCode.OK;
                response.status = true;
                response.count = 1;
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }

        public async Task<CommonResponse> GetAvailableColours()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var list = await _repository.GetAvailableColours();
                response.data = list;
                response.message = "Success";
                response.statusCode = HttpStatusCode.OK;
                response.status = true;
                response.count = 1;
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }

        public async Task<CommonResponse> GetAvailableSizes()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var list = await _repository.GetAvailableSizes();
                response.data = list;
                response.message = "Success";
                response.statusCode = HttpStatusCode.OK;
                response.status = true;
                response.count = 1;
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }


    }
}
