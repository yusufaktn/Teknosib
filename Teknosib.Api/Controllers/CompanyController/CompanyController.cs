using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teknosib.Business.Dto.CompanyDto;
using Teknosib.Business.Interface;

namespace Teknosib.Api.Controllers.CompanyController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyDto createCompanyDto)
        {
            var response = await _companyService.CreateCompanyAsync(createCompanyDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }

    }
}
