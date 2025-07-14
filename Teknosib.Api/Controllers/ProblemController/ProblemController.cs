using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teknosib.Business.Dto.ProblemDto;
using Teknosib.Business.Interface;

namespace Teknosib.Api.Controllers.ProblemController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemController : ControllerBase
    {

        private readonly IProblemService _problemService;

        public ProblemController(IProblemService problemService)
        {
            _problemService = problemService;
        }

        [HttpPost("CreateProblem")]
        [Authorize(Roles ="SuperAdmin")]
        public async Task<IActionResult> CreateProblem(CreateProblemDto createProblemDto)
        {
            var response = await _problemService.CreateProblemAsync(createProblemDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }

        [HttpDelete("DeleteProblem")]
        [Authorize(Roles ="SuperAdmin")]
        public async Task<IActionResult> DeleteProblem(DeleteProblemDto deleteProblemDto)
        {

            var response = await _problemService.DeleteProblemAsync(deleteProblemDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }

        [HttpDelete("HardDeleteProblem")]
        [Authorize(Roles ="SuperAdmin")]

        public async Task<IActionResult> HardDeleteProblem(DeleteProblemDto hardDeleteProblemDto)
        {

            var response = await _problemService.HardDeleteProblemAsync(hardDeleteProblemDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }



        [HttpGet("GetByProblemId")]
        [Authorize(Roles ="SuperAdmin")]            
        public async Task<IActionResult> GetByProblemId(Guid id)
        {
            var response = await _problemService.GetByIdProblemAsync(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }


        [HttpGet("GetProblemList")]
        [Authorize(Roles ="SuperAdmin")]     
        public async Task<IActionResult> GetProblemList()
        {
            var response = await _problemService.GetProblemListAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }

        [HttpGet("GetProblemListWithStatusFalse")]
        [Authorize(Roles ="SuperAdmin")]

        public async Task<IActionResult> GetProblemListWithStatusFalse()
        {
            var response = await _problemService.GetProblemListWithStatusFalseAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("UpdateProblem")]
        [Authorize(Roles ="SuperAdmin")]
        public async Task<IActionResult> UpdateProblem(Guid id,UpdateProblemDto updateProblemDto)
        {
            var response = await _problemService.UpdateProblemAsync(id,updateProblemDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("GetProblemByCategoryId")]
        [Authorize(Roles ="SuperAdmin")]

        public async Task<IActionResult> GetProblemByCategoryId(Guid categoryId)
        {
            var response = await _problemService.GetProblemByCategoryIdAsync(categoryId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }



    }
}
