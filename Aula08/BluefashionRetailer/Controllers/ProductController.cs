using BluefashionRetailer.API;
using BluefashionRetailer.Models;
using BluefashionRetailer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BluefashionRetailer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : APIBaseController
    {
        IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Index() => ApiOk(_service.All());
       

        [Route("{id}")]
        [HttpGet]
        public IActionResult Index(int? id)
        {
            Product existente = _service.Get(id);

            return existente == null ? ApiNotFound("O produto solicitado não foi encontrado") : ApiOk(existente);
        }
        [Route("Random"), HttpGet]
        public IActionResult Random()
        {
            Random rand = new();
            List<Product> list = _service.All();
            return ApiOk(list[rand.Next(list.Count)]);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product prod) =>
            _service.Create(prod) ? ApiOk("Produto criado com sucesso!") : ApiNotFound("Erro ao criar o produto!");

        [HttpPut]
        public IActionResult Update([FromBody] Product prod) =>
            _service.Update(prod) ? ApiOk("O produto foi editado com sucesso!") : ApiNotFound("Erro ao editar o produto");


        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int? id) =>
            _service.Delete(id) ? ApiOk("Produto excluído com sucesso") : ApiNotFound("Erro ao excluir o produto");
        
    }
}
