using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teknosib.Business.Dto.ProjectDto;
using Teknosib.Business.Dto.ProposalDto;
using Teknosib.Business.Interface;
using Teknosib.Business.Services;

namespace Teknosib.Api.Controllers.ProposalController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalController : ControllerBase
    {
        private readonly IProposalService _proposalService;

        public ProposalController(IProposalService proposalService)
        {
            _proposalService = proposalService;
        }

        [HttpPost("CreateProposal")]
        public async Task<IActionResult> CreateProposal(CreateProposalDto createProposalDto)
        {
            var response = await _proposalService.CreateProposalAsync(createProposalDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("GetListProposal")]
        public async Task<IActionResult> GetListProposal()
        {
            var response = await _proposalService.GetProposalListAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("DeleteProposal")]
        public async Task<IActionResult> DeleteProposal(DeleteProposalDto deleteProposalDto)
        {
            var response = await _proposalService.DeleteProposalAsync(deleteProposalDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("HardDeleteProposal")]
        public async Task<IActionResult> HardDeleteProposal(DeleteProposalDto deleteProposalDto)
        {
            var response = await _proposalService.HardDeleteProposalAsync(deleteProposalDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }


        [HttpGet("GetByIdProposal")]
        public async Task<IActionResult> GetByIdProposal(Guid id)
        {
            var response = await _proposalService.GetByIdProposalAsync(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("GetProposal_WithStatusFalse")]
        public async Task<IActionResult> GetProposaltWithStatusFalse()
        {
            var response = await _proposalService.GetProposalListWithStatusFalseAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("UpdateProposal")]
        public async Task<IActionResult> UpdateProposal(Guid id, UpdateProposalDto updateProposalDto)
        {
            var response = await _proposalService.UpdateProposalAsync(id, updateProposalDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }

    }
}
