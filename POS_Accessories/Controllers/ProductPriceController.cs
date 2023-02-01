using Microsoft.AspNetCore.Mvc;
using POS_Accessories.Business.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPriceController : BaseController
    {
        private readonly IProductPriceService _service;
        private readonly IConfiguration _configuration;
        public ProductPriceController(IProductPriceService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        [HttpGet("GetPagedCategories")]
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
        public async Task<IActionResult> GetAll(int productId)
        {
            var result = await _service.GetAllAsync(productId);
            return Json(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {           
            var result = await _service.GetByIdAsync(id);
            return Json(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(ProductPriceMap request)
        {
            var result = await _service.CreateAsync(request);
            return Json(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(ProductPriceMap request)
        {
            var result = await _service.UpdateAsync(request);
            return Json(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return Json(result);
        }
    }
}
