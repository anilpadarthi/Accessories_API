using Microsoft.AspNetCore.Mvc;
using POS_Accessories.Business.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : BaseController
    {
        private readonly ISubCategoryService _service;
        private readonly IConfiguration _configuration;
        public SubCategoryController(ISubCategoryService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        [HttpGet("GetByPaging")]
        public async Task<IActionResult> GetByPaging(int? pageNo, int? pageSize, string? searchText)
        {
            GetPagedRequest request = new GetPagedRequest();
            //request.mode = string.IsNullOrEmpty(searchText) ? DbActions.GetAll : DbActions.Search;
            request.pageNo = pageNo ?? int.Parse(_configuration["PageNumber"]);
            request.pageSize = pageSize ?? int.Parse(_configuration["PageSize"]);
            request.searchText = searchText;
            var result = await _service.GetAllSubCategoriesAsync();
            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllSubCategoriesAsync();
            return Json(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {           
            var result = await _service.GetSubCategoryAsync(id);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubCategory request)
        {
            var result = await _service.CreateSubCategoryAsync(request);
            return Json(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(SubCategory request)
        {
            var result = await _service.UpdateSubCategoryAsync(request);
            return Json(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteSubCategoryAsync(id);
            return Json(result);
        }
    }
}
