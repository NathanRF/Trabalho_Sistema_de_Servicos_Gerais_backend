using APIProdutos.Models;
using APIProdutos.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APIProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public object Post(
            [FromBody]UserModel user,
            [FromServices]AccessManager accessManager)
        {
            var result = accessManager.ValidateSignUp(user);
            return new { 
                Result = result
            };
        }
    }
}
