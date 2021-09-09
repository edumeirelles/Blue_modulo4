using BluefashionRetailer.API;
using BluefashionRetailer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BluefashionRetailer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        List<Product> All()
        {
            List<Product> lista = new();
            lista.Add(new Product() { Id = 1, Name = "Camiseta Regata", Price = 30, Description = "Descrição 1" });
            lista.Add(new Product() { Id = 2, Name = "Camiseta Manga Longa", Price = 80, Description = "Descrição 2" });
            lista.Add(new Product() { Id = 3, Name = "Camisa Social", Price = 100, Description = "Descrição 3" });
            lista.Add(new Product() { Id = 4, Name = "Calça Jeans", Price = 1200, Description = "Descrição 4" });
            lista.Add(new Product() { Id = 5, Name = "Chapéu", Price = 900, Description = "Descrição 5" });

            return lista;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new APIResponse<List<Product>>() { Results = All() });
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult Index(int? id)
        {
            Product produtoExistente = All().Find(x => x.Id == id);
            var response = new APIResponse<Product>();
            if (produtoExistente == null)
            {
                response.Error = "Não foi encontrado o produto solicitado";
                return NotFound(response);
            }
            else
            {
                response.Results = produtoExistente;
                return Ok(response);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product prod)
        {
            List<Product> produtos = All();
            prod.Id = produtos.Max(x => x.Id) + 1;
            Product produtoExistente = All().Find(x => x.Name == prod.Name);

            var response = new APIResponse<Product>();
            if (produtoExistente == null)
            {
                response.Results = prod;
                return Ok(response);
            }
            else
            {
                response.Error = "Já existe um produto com o nome informado";
                return NotFound(response);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Product prod)
        {
            List<Product> produtos = All();
            Product produtoExistente = All().Find(x => x.Id == prod.Id);

            var response = new APIResponse<Product>();
            if (produtoExistente == null)
            {
                response.Error = "Não foi encontrado o produto solicitado!";
                return NotFound(response);
            }
            else
            {
                response.Results = prod;
                return Ok(response);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            List<Product> produtos = All();
            Product produtoExistente = All().Find(x => x.Id == id);

            var response = new APIResponse<Product>();
            if (produtoExistente == null)
            {
                response.Error = "Não foi encontrado o produto solicitado!";
                return NotFound(response);
            }
            else
            {
                response.Results = produtoExistente;
                return Ok(response);
            }
        }
    }
}
