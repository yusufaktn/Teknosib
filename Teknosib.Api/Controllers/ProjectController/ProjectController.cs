using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teknosib.Business.Dto.InstitutionDto;
using Teknosib.Business.Dto.ProjectDto;
using Teknosib.Business.Interface;

namespace Teknosib.Api.Controllers.ProjectController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost("CreateProject")]
        public async Task<IActionResult> CreateProject(CreateProjectDto createProjectDto)
        {
            var response = await _projectService.CreateProjectAsync(createProjectDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("GetListProject")]
        public async Task<IActionResult> GetListProject()
        {
            var response = await _projectService.GetProjectListAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("DeleteProject")]
        public async Task<IActionResult> DeleteProject(DeleteProjectDto deleteProjectDto)
        {
            var response = await _projectService.DeleteProjectAsync(deleteProjectDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("HardDeleteProject")]
        public async Task<IActionResult> HardDeleteProject(DeleteProjectDto deleteProjectDto)
        {
            var response = await _projectService.HardDeleteProjectAsync(deleteProjectDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }


        [HttpGet("GetByIdProject")]
        public async Task<IActionResult> GetByIdProject(Guid id)
        {
            var response = await _projectService.GetByIdProjectAsync(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("GetProject_WithStatusFalse")]
        public async Task<IActionResult> GetProjectWithStatusFalse()
        {
            var response = await _projectService.GetProjectListWithStatusFalseAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("UpdateProject")]
        public async Task<IActionResult> UpdateProject(Guid id, UpdateProjectDto updateProjectDto)
        {
            var response = await _projectService.UpdateProjectAsync(id, updateProjectDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }
    }
}
