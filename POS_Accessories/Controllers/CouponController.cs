using Microsoft.AspNetCore.Mvc;
using POS_Accessories.Business.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : BaseController
    {
        private readonly ICouponService _service;
        private readonly IConfiguration _configuration;
        public CouponController(ICouponService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        [HttpGet("GetPagedCategories")]
        public async Task<IActionResult> GetPagedCategories(int? pageNo, int? pageSize, string? searchText)
        {
            GetPagedSearch request = new GetPagedSearch();
            //request.mode = string.IsNullOrEmpty(searchText) ? DbActions.GetAll : DbActions.Search;
            request.pageNo = pageNo ?? int.Parse(_configuration["PageNumber"]);
            request.pageSize = pageSize ?? int.Parse(_configuration["PageSize"]);
            request.searchText = searchText;
            var result = await _service.GetAllCouponsAsync();
            return Json(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllCouponsAsync();
            return Json(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {           
            var result = await _service.GetCouponAsync(id);
            return Json(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Coupon request)
        {
            var result = await _service.CreateCouponAsync(request);
            return Json(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(Coupon request)
        {
            var result = await _service.UpdateCouponAsync(request);
            return Json(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteCouponAsync(id);
            return Json(result);
        }
    }
}
