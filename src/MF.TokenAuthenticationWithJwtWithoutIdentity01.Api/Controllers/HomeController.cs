using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MF.TokenAuthenticationWithJwtWithoutIdentity01.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Ok(new { sucesso = true, resultado = "Olá! " + User.Identity.Name + " (Você está logado)" });
            }
            else
            {
                return Ok(new { sucesso = true, resultado = "Olá! Visitante (Você não está logado)" });
            }            
        }
    }
}
