using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Teknosib.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("herkes")]

        public IActionResult GetPublicResult()
        {

            return Ok("Bu bilgiler herkese açıktır");

        }


        [HttpGet("Secret")]
        [Authorize]

        public IActionResult GetSecretData()
        {
            // kimlik bilgileri (Claim'ler) artık erişilebilirdir.
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var userEmail = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
            var userRole = User.FindFirst("role")?.Value;

            return Ok($"Bu gizli bilgi sadece token sahibi kullanıcılar içindir. ID: {userId}, Email: {userEmail}, Rol: {userRole}");


        }




    }
}
