using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSG_API.Security;
using System;
using System.Linq;
using SSG_API.Business;

namespace SSG_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class PrestadoresController : ControllerBase
    {
        private readonly PrestadorService _prestadorService;

        public PrestadoresController(PrestadorService prestadorService)
        {
            _prestadorService = prestadorService;
        }

        [HttpGet]
        public ActionResult<object> Get([FromQuery] string email="", [FromQuery] string id="")
        {
            object result = null;

            if (id != string.Empty)
                result = _prestadorService.GetById(id);
            else 
                if (email != string.Empty)
                    result = _prestadorService.GetByEmail(email);


            if (result != null)
                return Ok(result);
            
            return NotFound(new {Message = "Prestador não encontrado"});
        }
    }
}
