using BlueFashionRetailer.API;
using BlueFashionRetailer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BlueFashionRetailer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ApiBaseController
    {
        IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }


        /// <summary>
        /// Cria um novo usuário
        /// </summary>
        /// <param name="identityUser"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] IdentityUser identityUser)
        {
            IdentityResult result = _service.Create(identityUser).Result;
            identityUser.PasswordHash = null;
            return result.Succeeded ?
                ApiOk(identityUser) :
                ApiBadRequest(result.Errors, "Erro ao criar usuário");
        }

        /// <summary>
        /// Gera Token de autenticação
        /// </summary>
        /// <param name="identityUser"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Token")]
        [AllowAnonymous]
        public IActionResult Token([FromBody] IdentityUser identityUser)
        {
            try 
            {
                return ApiOk(_service.GenerateToken(identityUser));
            }
            catch(Exception e)
            {
                return ApiBadRequest(e, e.Message);
            }
        }
    }
}
