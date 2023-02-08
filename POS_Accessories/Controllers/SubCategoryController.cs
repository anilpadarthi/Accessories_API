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


        [HttpPost("GetByPaging")]
        public async Task<IActionResult> GetByPaging(GetPagedSearch request)
        {
            var result = await _service.GetByPagingAsync(request);
            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int categoryId)
        {
            var result = await _service.GetAllAsync(categoryId);
            return Json(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubCategory request)
        {
            var result = await _service.CreateAsync(request);
            return Json(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(SubCategory request)
        {
            var result = await _service.UpdateAsync(request);
            return Json(result);
        }

        [HttpPut("UpdateStatus")]
        public async Task<IActionResult> UpdateStatus(SubCategory request)
        {
            var result = await _service.UpdateStatusAsync(request.SubCategoryId, request.Status);
            return Json(result);
        }
    }
}
