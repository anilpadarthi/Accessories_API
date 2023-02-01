using Microsoft.AspNetCore.Mvc;
using POS_Accessories.Business.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IProductService _service;
        private readonly IConfiguration _configuration;
        public ProductController(IProductService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        [HttpGet("GetByPaging")]
        public async Task<IActionResult> GetPagedCategoriesAsync(int? pageNo, int? pageSize, string? searchText)
        {
            GetPagedSearch request = new GetPagedSearch();
            //request.mode = string.IsNullOrEmpty(searchText) ? DbActions.GetAll : DbActions.Search;
            request.pageNo = pageNo ?? int.Parse(_configuration["PageNumber"]);
            request.pageSize = pageSize ?? int.Parse(_configuration["PageSize"]);
            request.searchText = searchText;
            var result = await _service.GetByPagingAsync(request);
            return Json(result);
        }

        [HttpPost("GetByPaging")]
        public async Task<IActionResult> GetByPaging(GetPagedSearch request)
        {
            var result = await _service.GetByPagingAsync(request);
            return Json(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Json(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {           
            var result = await _service.GetByIdAsync(id);
            return Json(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Product request)
        {
            var result = await _service.CreateAsync(request);
            return Json(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(Product request)
        {
            var result = await _service.UpdateAsync(request);
            return Json(result);
        }

        [HttpPut("UpdateStatus")]
        public async Task<IActionResult> UpdateStatus(Product request)
        {
            var result = await _service.UpdateStatusAsync(request.ProductId, request.Status);
            return Json(result);
        }
    }
}
