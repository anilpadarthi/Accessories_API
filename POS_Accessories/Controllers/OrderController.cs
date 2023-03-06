using Microsoft.AspNetCore.Mvc;
using POS_Accessories.Business.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        private readonly IOrderService _service;
        private readonly IConfiguration _configuration;
        public OrderController(IOrderService service, IConfiguration configuration)
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
      

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {           
            var result = await _service.GetByIdAsync(id);
            return Json(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(OrderDetailsModel request)
        {
            var result = await _service.CreateAsync(request);
            return Json(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(OrderDetailsModel request)
        {
            var result = await _service.UpdateAsync(request);
            return Json(result);
        }

        [HttpPut("UpdateStatus")]
        public async Task<IActionResult> UpdateStatus(OrderStatusModel request)
        {
            var result = await _service.UpdateStatusAsync(request);
            return Json(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            //var result = await _service.DeleteAs(id);
            return Json("");
        }
    }
}
