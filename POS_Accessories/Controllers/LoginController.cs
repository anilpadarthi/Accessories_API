using Microsoft.AspNetCore.Mvc;
using POS_Accessories.Business.Interfaces;

namespace POS_Accessories.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUserService _service;
        public LoginController(IUserService service)
        {
            _service = service;
        }
        [HttpGet("Authenticate")]
        public async Task<IActionResult> Authenticate(string email, string password)
        {
            var result = await _service.AuthenticateUser(email,password);
            return Json(result);
        }
        
    }
}
