using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSG_API.Business;
using SSG_API.Models;
using SSG_API.Domain;
using System.Collections.Generic;

namespace SSG_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize("Bearer")]
    public class ProdutosController : ControllerBase
    {
        private ProdutoService _service;

        public ProdutosController(ProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            return _service.ListarTodos();
        }

        [HttpGet("{codigoBarras}")]
        public ActionResult<Produto> Get(string codigoBarras)
        {
            var produto = _service.Obter(codigoBarras);
            if (produto != null)
                return produto;
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult<Resultado> Post([FromBody] Produto produto)
        {
            return _service.Incluir(produto);
        }

        [HttpPut]
        public ActionResult<Resultado> Put([FromBody] Produto produto)
        {
            return _service.Atualizar(produto);
        }

        [HttpDelete("{codigoBarras}")]
        public ActionResult<Resultado> Delete(string codigoBarras)
        {
            return _service.Excluir(codigoBarras);
        }
    }
}