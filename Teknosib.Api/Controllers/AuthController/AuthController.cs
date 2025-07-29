using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Teknosib.Business.Dto.AuthDto.LoginDto;
using Teknosib.Business.Dto.AuthDto.RegisterDto;
using Teknosib.Business.Dto.TokenDto;
using Teknosib.Business.Interface;

namespace Teknosib.Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("Login")]

        public async Task<IActionResult> Login(LoginDto loginDto)
        {

            var response = await _authService.LoginAsync(loginDto);

            if(response.IsSuccess)
            {

                return Ok(response);
            }

            return BadRequest(response);

        }


        [HttpPost("register-Company")]
        public async Task<IActionResult> RegisterCompany(RegisterCompanyDto registerCompanyDto)
        {

            var response = await _authService.RegisterCompanyAsync(registerCompanyDto);

            if(response.IsSuccess)
            {

                return Ok(response);
            }

            return BadRequest(response);

        }

        [HttpPost("register-Institution")]
        public async Task<IActionResult> RegisterInstitutionIProvider(RegisterInstitutionDto registerInstitutionDto)
        {
            var response  = await _authService.RegisterIntitutionAsync(registerInstitutionDto);

            if (response.IsSuccess)
            {

                return Ok(response);
            }
            return BadRequest(response);
        }


        [HttpPost("register-User")]

        public async Task<IActionResult> RegisterUserProvider(RegisterUserDto registerUserDto)
        {

            var response = await _authService.RegisterUserAsync(registerUserDto);

            if(response.IsSuccess)
            {

                return Ok(response);
            }
            return BadRequest(response);

        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshTokenLogin(TokensDto tokensDto)
        {
            var result = await _authService.RefreshToken(tokensDto.RefreshToken);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return Unauthorized(result);

        }


    }
}
