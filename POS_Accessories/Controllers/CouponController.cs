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

        [HttpPost("GetByPaging")]
        public async Task<IActionResult> GetByPaging(GetPagedSearch request)
        {
            var result = await _service.GetByPagingAsync(request);
            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Json(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CouponRequestModel request)
        {
            var result = await _service.CreateAsync(request);
            return Json(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CouponRequestModel request)
        {
            var result = await _service.UpdateAsync(request);
            return Json(result);
        }

        [HttpPut("UpdateStatus")]
        public async Task<IActionResult> UpdateStatus(CouponRequestModel request)
        {
            var result = await _service.UpdateStatusAsync(request.CouponId, request.Status);
            return Json(result);
        }
    }
}
