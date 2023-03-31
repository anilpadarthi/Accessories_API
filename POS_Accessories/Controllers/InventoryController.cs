using Microsoft.AspNetCore.Mvc;
using POS_Accessories.Business.Interfaces;
using POS_Accessories.Models.Request;
using POS_Accessories.Models;

namespace POS_Accessories.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : BaseController
    {
        private readonly IInventoryService _service;
        public InventoryController(IInventoryService service)
        {
            _service = service;
        }

        [HttpPost("GetWareHouseResult")]
        public async Task<IActionResult> GetWareHouseResult(GetPagedSearch request)
        {
            var result = await _service.GetWareHouseResultAsync(request);
            return Json(result);
        }

        [HttpPost("GetStockPurchaseHistoyResult")]
        public async Task<IActionResult> GetStockPurchaseHistoyResult(GetPagedSearch request)
        {
            var result = await _service.GetStockPurchaseHistoyResultAsync(request);
            return Json(result);
        }

    }
}
