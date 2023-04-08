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

        [HttpGet("OrderPaymentTypes")]
        public async Task<IActionResult> GetOrderPaymentTypes()
        {
            var result = await _service.GetOrderPaymentTypes();
            return Json(result);
        }

        [HttpGet("OrderDeliveryTypes")]
        public async Task<IActionResult> GetOrderDeliveryTypes()
        {
            var result = await _service.GetOrderDeliveryTypes();
            return Json(result);
        }

        [HttpGet("Agents")]
        public async Task<IActionResult> GetAgents()
        {
            var result = await _service.GetAgents();
            return Json(result);
        }


        [HttpGet("Managers")]
        public async Task<IActionResult> GetManagers()
        {
            var result = await _service.GetManagers();
            return Json(result);
        }


        [HttpGet("Areas")]
        public async Task<IActionResult> GetAreas()
        {
            var result = await _service.GetAreas();
            return Json(result);
        }

        [HttpGet("Shops")]
        public async Task<IActionResult> GetShops(int areaId)
        {
            var result = await _service.GetShops(areaId);
            return Json(result);
        }

    }
}
