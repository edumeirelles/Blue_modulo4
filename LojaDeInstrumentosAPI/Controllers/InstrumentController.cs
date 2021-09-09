using LojaDeInstrumentosAPI.API;
using LojaDeInstrumentosAPI.Models;
using LojaDeInstrumentosAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace LojaDeInstrumentosAPI.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class InstrumentController : APIBaseController
    {
        IInstrumentService _service;
        public InstrumentController(IInstrumentService service)
        {
            _service = service;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public IActionResult Index() => ApiOk(_service.All());

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        [HttpGet]
        public IActionResult Index(int? id)
        {
            Instrument existente = _service.Get(id);

            return existente == null ? ApiNotFound("Não foi encontrado o produto solicitado.") : ApiOk(existente);
        }

        [Route("Random"), HttpGet]
        public IActionResult Random()
        {
            Random rand = new();
            List<Instrument> list = _service.All();
            return ApiOk(list[rand.Next(list.Count)]);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Instrument instrument)
        {
            var x = User.Claims.ToList();
            instrument.createdById = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return _service.Create(instrument) ? ApiOk("Produto criado com sucesso!") : ApiNotFound("Erro ao criar o produto!");
        }
           

        [HttpPut]
        public IActionResult Update([FromBody] Instrument instrument)
        {
            instrument.updatedById = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return _service.Update(instrument) ? ApiOk("O produto foi editado com sucesso!") : ApiNotFound("Erro ao editar o produto");
        }

        [AuthorizeRoles(RoleType.Admin)]
        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int? id) =>
            _service.Delete(id) ? ApiOk("Produto excluído com sucesso") : ApiNotFound("Erro ao excluir o produto");

        [AllowAnonymous]
        [Route("InstrumentByRole/{role?}")]
        [HttpGet]
        public IActionResult InstrumentByRole(string role)
        {
            return ApiOk(_service.InstrumentByUserRole(role));
        }

    }
}
