using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace POS_Accessories.Controllers
{
    [ApiController]
    [Authorize]
    public class BaseController : Controller
    {
        //public int GetUserId
        //{
        //    get
        //    {
        //        if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
        //        {
        //            ClaimsIdentity claimIdentity = User.Identity as ClaimsIdentity;
        //            User userObj = JsonConvert.DeserializeObject<User>(claimIdentity.FindFirst("user").Value);
        //            return userObj.UserId;
        //        }
        //        return new int();
        //    }
        //}
        //public User GetUser
        //{
        //    get
        //    {
        //        if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
        //        {
        //            ClaimsIdentity claimIdentity = User.Identity as ClaimsIdentity;
        //            User userObj = JsonConvert.DeserializeObject<User>(claimIdentity.FindFirst("user").Value);
        //            return userObj;
        //        }
        //        return null;
        //    }
        //}
    }
}
