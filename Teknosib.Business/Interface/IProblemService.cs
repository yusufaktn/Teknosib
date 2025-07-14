using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.CategoryDto;
using Teknosib.Business.Dto.ProblemDto;


namespace Teknosib.Business.Interface
{
    public interface IProblemService
    {

        Task<ResponseDto<List<ProblemDto>>> GetProblemListAsync();
        Task<ResponseDto<List<ProblemDto>>> GetProblemListWithStatusFalseAsync();
        Task<ResponseDto<ProblemDto>> GetByIdProblemAsync(Guid id);
        Task<ResponseDto<ProblemDto>> CreateProblemAsync(CreateProblemDto createProblemDto);
        Task<ResponseDto<UpdateProblemDto>> UpdateProblemAsync(Guid id,UpdateProblemDto updateProblemDto);
        Task<ResponseDto<object>> DeleteProblemAsync(DeleteProblemDto deleteProblemDto);
        Task<ResponseDto<object>> HardDeleteProblemAsync(DeleteProblemDto deleteProblemDto);
        Task<ResponseDto<List<ProblemDto>>> GetProblemByCategoryIdAsync(Guid id);



    }
}
