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

    }
}
