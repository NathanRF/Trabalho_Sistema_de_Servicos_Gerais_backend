using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSG_API.Business;
using SSG_API.Data;
using SSG_API.Domain;
using SSG_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SSG_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class ServicosPrestadosController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ServicosPrestadosController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ServicoPrestado>> Get()
        {
            var result = _applicationDbContext.ServicosPrestados.ToList<object>();

            if(result.Any())
                return Ok(result);
            else
                return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<ServicoPrestado> Get(string id)
        {
            var result = _applicationDbContext.ServicosPrestados.Find(id);

            if(result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult<ServicoPrestado> Post([FromBody] ServicoPrestadoModel servico)
        {
            var result = _applicationDbContext.Add<ServicoPrestado>(
                new ServicoPrestado()
                {
                    Servico = _applicationDbContext.Find<Servico>(servico.Servico),
                    Prestador = _applicationDbContext.Find<Prestador>(servico.Prestador),
                    Unidade = _applicationDbContext.Find<UnidadeDeCobranca>(servico.Unidade),
                    Preco = servico.Preco
                }).Entity;
            _applicationDbContext.SaveChanges();
            
            return Ok(result);
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
