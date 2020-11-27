﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class OrdensDeServicoController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public OrdensDeServicoController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var result = _applicationDbContext.OrdensDeServico.ToList<object>();

            if (result.Any())
                return Ok(result);
            else
                return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<object> Get(Guid id)
        {
            var result = _applicationDbContext.Servicos.Find(id);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult<object> Post([FromBody] OrdemDeServicoModel value)
        {
            var result = _applicationDbContext.Add<OrdemDeServico>(
                new OrdemDeServico() 
                {
                    Prestador = _applicationDbContext.Prestadores.Find(value.Prestador),
                    Contratante = _applicationDbContext.Contratantes.Find(value.Contratante),
                    ServicoPrestado = _applicationDbContext.ServicosPrestados.Find(value.ServicoPrestado),
                    DataPrestacao = (DateTime)value.Data,
                    Preco = (double)value.Preco,
                    Endereco = value.Endereco,
                    Resumo = value.Resumo,
                    Status = (int)value.Status,
                    FormaPagamento = (int)value.FormaPagamento
                }
            ).Entity;

            _applicationDbContext.SaveChanges();

            return Ok(result);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] OrdemDeServicoModel value)
        {
            var actual = _applicationDbContext.OrdensDeServico.Find(id);
            var updated = new OrdemDeServico
            {
                Id = id,
                Contratante = actual.Contratante,
                Prestador = actual.Prestador,
                ServicoPrestado = actual.ServicoPrestado,
                FormaPagamento = value.FormaPagamento != null ? (int)value.FormaPagamento : actual.FormaPagamento,
                DataPrestacao = value.Data != null ? (DateTime)value.Data : actual.DataPrestacao,
                Endereco = value.Endereco != null ? value.Endereco : actual.Endereco,
                Preco = value.Preco != null ? (double)value.Preco : actual.Preco,
                Resumo = value.Resumo != null ? value.Resumo : actual.Resumo,
                Status = value.Status != null ? (int)value.Status : actual.Status
            };
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
