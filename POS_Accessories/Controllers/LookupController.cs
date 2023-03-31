using Microsoft.AspNetCore.Mvc;
using POS_Accessories.Business.Interfaces;

namespace POS_Accessories.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupController : BaseController
    {
        private readonly ILookupService _service;
        public LookupController(ILookupService service)
        {
            _service = service;
        }

        [HttpGet("Categories")]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _service.GetCategories();
            return Json(result);
        }

        [HttpGet("{categoryId}/SubCategories")]
        public async Task<IActionResult> GetSubCategories(int categoryId)
        {
            var result = await _service.GetSubCategories(categoryId);
            return Json(result);
        }

        [HttpGet("Colours")]
        public async Task<IActionResult> GetAvailableColours()
        {
            var result = await _service.GetAvailableColours();
            return Json(result);
        }

        [HttpGet("Sizes")]
        public async Task<IActionResult> GetAvailableSizes()
        {
            var result = await _service.GetAvailableSizes();
            return Json(result);
        }

        [HttpGet("ConfigurationTypes")]
        public async Task<IActionResult> GetConfigurationTypes()
        {
            var result = await _service.GetConfigurationTypes();
            return Json(result);
        }

        [HttpGet("Products")]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _service.GetProducts();
            return Json(result);
        }

        [HttpGet("Suppliers")]
        public async Task<IActionResult> GetSuppliers()
        {
            var result = await _service.GetSuppliers();
            return Json(result);
        }

        [HttpGet("OrderStatusTypes")]
        public async Task<IActionResult> GetOrderStatusTypes()
        {
            var result = await _service.GetOrderStatusTypes();
            return Json(result);
        }

        [HttpGet("GetOrderPaymentTypes")]
        public async Task<IActionResult> GetOrderPaymentTypes()
        {
            var result = await _service.GetOrderPaymentTypes();
            return Json(result);
        }

        [HttpGet("GetOrderDeliveryTypes")]
        public async Task<IActionResult> GetOrderDeliveryTypes()
        {
            var result = await _service.GetOrderDeliveryTypes();
            return Json(result);
        }

    }
}
