using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSG_API.Models;
using SSG_API.Security;

namespace SSG_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignUpController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<object> Post(
            [FromBody] SignUpUserModel user,
            [FromServices] AccessManager accessManager)
        {
            var result = accessManager.ValidateSignUp(user);
            return new
            {
                Result = result
            };
        }
    }
}
