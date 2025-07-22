using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teknosib.Business.Dto.ProjectDto;
using Teknosib.Business.Dto.SupportCallDto;
using Teknosib.Business.Interface;

namespace Teknosib.Api.Controllers.SupportCallController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportCallController : ControllerBase
    {
        private readonly ISupportCallService _supportCallService;

        public SupportCallController(ISupportCallService supportCallService)
        {
            _supportCallService = supportCallService;
        }

        [HttpPost("CreateSupportCall")]
        public async Task<IActionResult> CreateSupportCall(CreateSupportCallDto createSupportCallDto)
        {
            var response = await _supportCallService.Create_SupportCallAsync(createSupportCallDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("GetList_SupportCall")]
        public async Task<IActionResult> GetList_SupportCall()
        {
            var response = await _supportCallService.GetList_SupportCallAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("Delete_SupportCall")]
        public async Task<IActionResult> Delete_SupportCall(DeleteSupportCallDto deleteSupportCallDto)
        {
            var response = await _supportCallService.Delete_SupportCallAsync(deleteSupportCallDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("HardDelete_SupportCall")]
        public async Task<IActionResult> HardDeleteSupportCall(DeleteSupportCallDto deleteSupportCallDto)
        {
            var response = await _supportCallService.HardDelete_SupportCallAsync(deleteSupportCallDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }


        [HttpGet("GetById_SupportCall")]
        public async Task<IActionResult> GetById_SupportCall(Guid id)
        {
            var response = await _supportCallService.GetById_SupportCallAsync(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("GetSupportCall_WithStatusFalse")]
        public async Task<IActionResult> GetSupportCall_WithStatusFalse()
        {
            var response = await _supportCallService.GetListSupportCall_WithStatusFalseAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("Update_SupportCall")]
        public async Task<IActionResult> Update_SupportCall(Guid id, UpdateSupportCallDto updateSupportCallDto)
        {
            var response = await _supportCallService.Update_SupportCallAsync(id, updateSupportCallDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }
    }
}
