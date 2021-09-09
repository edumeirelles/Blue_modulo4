using BlueFashionRetailer.API;
using BlueFashionRetailer.Models;
using BlueFashionRetailer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlueFashionRetailer.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [AuthorizeRoles(RoleType.Common, RoleType.Admin)]
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ApiBaseController
    {
        IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }



        /// <summary>
        /// Retorna uma lista de todos os porodutos existentes no banco de dados
        /// </summary>
        /// <returns></returns>
        /// 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult Index() =>
            ApiOk(_service.All());


        /// <summary>
        /// Retorna um produto indentificado pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        [HttpGet]
        public IActionResult Index(int? id)
        {
            Product exists = _service.Get(id);
            return exists == null?
                ApiNotFound("Não foi encontrado o produto solicitado.") :
                ApiOk(exists);
        }


        /// <summary>
        /// Cria um novo produto
        /// </summary>
        /// <param name="prod"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] Product prod)
        {
            prod.createdById = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return _service.Create(prod) ?
                ApiOk("Produto criado com sucesso!") :
                ApiNotFound("Erro ao criar produto!");
        } 

        /// <summary>
        /// Edita um produto existente
        /// </summary>
        /// <param name="prod"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update([FromBody] Product prod)
        {
            prod.updatedById = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return _service.Update(prod) ?
                ApiOk("Produto atualizado com sucesso!") :
                ApiNotFound("Erro ao atualizar produto!");
        }

        /// <summary>
        /// Apaga um regitro de produto do banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AuthorizeRoles(RoleType.Admin)]
        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int? id) =>
            _service.Delete(id) ?
                ApiOk("Produto deletado com sucesso!") :
                ApiNotFound("Erro ao deletar produto!");

        /// <summary>
        /// Retorna os produtos de acordo com as Roles
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("ProductsByRole/{role?}")]
        [HttpGet]
        public IActionResult ProductsByRole(string role)
        {
            return ApiOk(_service.ProductsByUserRole(role));
        }
    }
}
