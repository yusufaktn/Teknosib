using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.ProblemDto;
using Teknosib.Business.Dto.ProjectDto;

namespace Teknosib.Business.Interface
{
    public interface IProjectService
    {
        Task<ResponseDto<List<ProjectDto>>> GetProjectListAsync();
        Task<ResponseDto<List<ProjectDto>>> GetProjectListWithStatusFalseAsync();
        Task<ResponseDto<ProjectDto>> GetByIdProjectAsync(Guid id);
        Task<ResponseDto<ProjectDto>> CreateProjectAsync(CreateProjectDto createProjectDto);
        Task<ResponseDto<UpdateProjectDto>> UpdateProjectAsync(Guid id, UpdateProjectDto updateProjectDto);
        Task<ResponseDto<object>> DeleteProjectAsync(DeleteProjectDto deleteProjectDto);
        Task<ResponseDto<object>> HardDeleteProjectAsync(DeleteProjectDto deleteProjectDto);
        Task<ResponseDto<List<ProjectDto>>> GetProjectByCategoryIdAsync(Guid id);
    }
}
