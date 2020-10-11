using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using APIProdutos.Security;
using APIProdutos.Models;

namespace APIProdutos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public object Post(
            [FromBody]UserModel usuario,
            [FromServices]AccessManager accessManager)
        {
            if (accessManager.ValidateLoginCredentials(usuario))
            {
                return accessManager.GenerateToken(usuario);
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