using POS_Accessories.Business.Helper;
using POS_Accessories.Business.Interfaces;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models.Response;
using System.Net;

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
                response = Utility.CreateResponse(list, HttpStatusCode.OK);
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
                response = Utility.CreateResponse(list, HttpStatusCode.OK);
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
                response = Utility.CreateResponse(list, HttpStatusCode.OK);
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
                response = Utility.CreateResponse(list, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }

        public async Task<CommonResponse> GetConfigurationTypes()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var list = await _repository.GetConfigurationTypes();
                response = Utility.CreateResponse(list, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }

        public async Task<CommonResponse> GetProducts()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var list = await _repository.GetProducts();
                response = Utility.CreateResponse(list, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }


    }
}
