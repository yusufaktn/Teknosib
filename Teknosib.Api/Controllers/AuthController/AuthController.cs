using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Teknosib.Business.Dto.AuthDto.LoginDto;
using Teknosib.Business.Dto.AuthDto.RegisterDto;
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


        [HttpPost("login")]

        public async Task<IActionResult> Login(LoginDto loginDto)
        {

            var response = await _authService.LoginAsync(loginDto);

            if(response.IsSuccess)
            {

                return Ok(new { Token = response });
            }

            return BadRequest(response);

        }


        [HttpPost("register-company")]
        public async Task<IActionResult> RegisterCompany(RegisterCompanyDto registerCompanyDto)
        {

            var response = await _authService.RegisterCompanyAsync(registerCompanyDto);

            if(response.IsSuccess)
            {

                return Ok(response);
            }

            return BadRequest(response);

        }

        [HttpPost("register-IndividualProvider")]
        public async Task<IActionResult> RegisterIndividualProvider(RegisterIndividualProviderDto registerIndividualProviderDto)
        {
            var response  = await _authService.RegisterIndividualAsync(registerIndividualProviderDto);

            if (response.IsSuccess)
            {

                return Ok(response);
            }
            return BadRequest(response);
        }


        [HttpPost("register-BusinessProvider")]

        public async Task<IActionResult> RegisterBusinessProvider(RegisterBusinessProviderDto registerBusinessProviderDto)
        {

            var response = await _authService.RegisterBusinessAsync(registerBusinessProviderDto);

            if(response.IsSuccess)
            {

                return Ok(response);
            }
            return BadRequest(response);

        }


    }
}
