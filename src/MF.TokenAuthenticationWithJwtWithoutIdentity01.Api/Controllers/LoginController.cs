using System.Linq;
using System.Threading.Tasks;
using MF.TokenAuthenticationWithJwtWithoutIdentity01.Api.Models;
using MF.TokenAuthenticationWithJwtWithoutIdentity01.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MF.TokenAuthenticationWithJwtWithoutIdentity01.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("logar")]
        public async Task<ActionResult> Logar(LoginDTO dtoLogin)
        {
            if (!ModelState.IsValid
                || dtoLogin.Usuario.ToLower() != "Mauricio".ToLower() 
                || dtoLogin.Senha.ToLower() != "123456".ToLower())
            {
                ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos");
                return BadRequest(new
                {
                    sucesso = false,
                    resultado = ModelState.Values.SelectMany(p => p.Errors.Select(e => e.ErrorMessage))
                });
            }           

            var token = 
                TokenService.GerarToken(dtoLogin, _configuration);

            return Ok(new 
            { 
                sucesso = true, 
                usuario = dtoLogin.Usuario,
                token = token
            });
        }      
    }
}
