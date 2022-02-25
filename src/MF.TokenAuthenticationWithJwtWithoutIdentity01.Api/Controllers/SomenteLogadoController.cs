using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MF.TokenAuthenticationWithJwtWithoutIdentity01.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SomenteLogadoController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Ok(new { sucesso = true, resultado = "Parabéns! Somente usuários logados podem ver esta página e você está logado!" });
            }
            else
            {
                return Ok(new { sucesso = true, resultado = "Algo de errado não está certo e você não deveria estar aqui!" });
            }
        }
    }
}
