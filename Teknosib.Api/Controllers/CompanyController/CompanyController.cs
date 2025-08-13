using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teknosib.Business.Dto.CompanyDto;
using Teknosib.Business.Dto.LegalEntityDto;
using Teknosib.Business.Interface;
using Teknosib.Business.Interface.File;
using Teknosib.Entity.Models.Enums;

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

        [HttpPost("CreateCompany")]
        public async Task<IActionResult> CreateCompany(CreateCompanyDto createCompanyDto)
        {
            var response = await _companyService.CreateCompanyAsync(createCompanyDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("GetListCompany")]
        public async Task<IActionResult> GetList()
        {
            var response = await _companyService.GetCompanyListAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("DeleteCompany")]
        public async Task<IActionResult> DeleteCompany(DeleteCompanyDto deleteCompanyDto)
        { 
            var response = await _companyService.DeleteCompanyAsync(deleteCompanyDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("HardDeleteCompany")]
        public async Task<IActionResult> HardDeleteCompany (DeleteCompanyDto deleteCompanyDto)
        {
            var response = await _companyService .HardDeleteAsync(deleteCompanyDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }


        [HttpGet("GetByIdCompany")]
        public async Task<IActionResult> GetByIdCompany(Guid id)
        {
            var response = await _companyService.GetByIdCompanyAsync(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("GetCompanyWithStatusFalse")]
        public async Task<IActionResult> GetCompanyWithStatusFalse()
        {
            var response = await _companyService.GetCompanyWithStatusFalseAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("UpdateCompany")]
        public async Task<IActionResult> UpdateCompany(Guid id,UpdateCompanyDto updateCompanyDto)
        {
            var response = await _companyService.UpdateCompanyAsync(id,updateCompanyDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }

        [HttpPost("SaveCompanyLogo")]
        public async Task<IActionResult> SaveCompanyLogo(Guid id, IFormFile file)
        {
            if(file is null || file.Length == 0)
            {
                return BadRequest("Lütfen bir dosya seçin.");
            }
            var reponse = await _companyService.SaveCompanyLogo(id,file);
            if (reponse.IsSuccess)
            {
                return Ok(reponse);
            }
            return BadRequest(reponse);

        }

        [HttpPut("UpdateApproveStatus")]
        public async Task<IActionResult> UpdateApprove(ApproveDto approveDto)
        {
            var response = await _companyService.ApproveStatusCompany(approveDto.Id,approveDto.ApproveStatus);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);    
        }

        

    }
}
