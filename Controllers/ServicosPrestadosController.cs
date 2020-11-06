using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSG_API.Domain;
using SSG_API.Models;
using System;
using System.Collections.Generic;

namespace SSG_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class ServicosPrestadosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<ServicoPrestado>> Get()
        {
            throw new NotImplementedException();
            //return //Listar todos serviços
        }

        [HttpGet("{id}")]
        public ActionResult<ServicoPrestado> Get(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult<ServicoPrestado> Post([FromBody] ServicoPrestado servico)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public ActionResult<Resultado> Put([FromBody] ServicoPrestado servico)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public ActionResult<Resultado> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
