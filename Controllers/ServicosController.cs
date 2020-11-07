using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSG_API.Data;
using SSG_API.Domain;
using SSG_API.Models;

namespace SSG_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class ServicosController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ServicosController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var result = _applicationDbContext.Servicos.ToList<object>();

            if(result.Any())
                return Ok(result);
            else
                return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<object> Get(Guid id)
        {
            var result = _applicationDbContext.Servicos.Find(id);

            if(result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult<object> Post([FromBody] ServicoModel value)
        {
            var result = _applicationDbContext.Add<Servico>(new Servico(){ Nome = value.Nome, DescricaoServico = value.DescricaoServico}).Entity;
            _applicationDbContext.SaveChanges();
            
            return Ok(result);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
