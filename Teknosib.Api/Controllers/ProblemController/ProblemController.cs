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
        public async Task<IActionResult> CreateProblem(CreateProblemDto createProblemDto)
        {
            var response = await _problemService.CreateProblemAsync(createProblemDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }


    }
}
