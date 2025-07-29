using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teknosib.Business.Dto.CompanyDto;
using Teknosib.Business.Dto.InstitutionDto;
using Teknosib.Business.Interface;

namespace Teknosib.Api.Controllers.InstitutionController
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutionController : ControllerBase
    {
        private readonly IInstitutionService _institutionService;

        public InstitutionController(IInstitutionService institutionService)
        {
            _institutionService = institutionService;
        }

        [HttpPost("CreateInstitution")]
        public async Task<IActionResult> CreateInstitution(CreateInstitutionDto createInstitutionDto)
        {
            var response = await _institutionService.CreateInstitutionAsync(createInstitutionDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("GetListInstitution")]
        public async Task<IActionResult> GetListInstitution()
        {
            var response = await _institutionService.GetInstitutionListAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("DeleteInstitution")]
        public async Task<IActionResult> DeleteInstitution(DeleteInstitutionDto deleteInstitutionDto)
        {
            var response = await _institutionService.DeleteInstitutionAsync(deleteInstitutionDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("HardDeleteInstitution")]
        public async Task<IActionResult> HardDeleteInstitution(DeleteInstitutionDto deleteInstitutionDto)
        {
            var response = await _institutionService.HardDeleteInstitutionAsync(deleteInstitutionDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }


        [HttpGet("GetByIdInstitution")]
        public async Task<IActionResult> GetByIdInstitution(Guid id)
        {
            var response = await _institutionService.GetByIdInstitutionAsync(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("GetInstitution_WithStatusFalse")]
        public async Task<IActionResult> GetInstitutionWithStatusFalse()
        {
            var response = await _institutionService.GetInstitutionWithStatusFalseAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("UpdateInstitution")]
        public async Task<IActionResult> UpdateInstitution(Guid id, UpdateInstitutionDto updateInstitutionDto)
        {
            var response = await _institutionService.UpdateInstitutionAsync(id, updateInstitutionDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }

        [HttpPost("SaveInstitutionLogo")]
        public async Task<IActionResult> SaveInstitutionLogo(Guid institutionId,IFormFile formFile)
        {
            var response = await _institutionService.SaveInstitutionLogo(institutionId, formFile);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }

    }
}
