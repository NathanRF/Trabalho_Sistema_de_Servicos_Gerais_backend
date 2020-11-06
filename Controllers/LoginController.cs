using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSG_API.Models;
using SSG_API.Security;

namespace SSG_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<object> Post(
            [FromBody] SignInUserModel usuario,
            [FromServices] AccessManager accessManager)
        {
            if (accessManager.ValidateLoginCredentials(usuario))
            {
                ClaimsPrincipal claims = this.User;
                return accessManager.GenerateToken(usuario, claims);
            }
            else
            {
                return new
                {
                    Authenticated = false,
                    Message = "Falha ao autenticar"
                };
            }
        }
    }
}