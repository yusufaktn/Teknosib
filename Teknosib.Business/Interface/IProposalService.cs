using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.ProjectDto;
using Teknosib.Business.Dto.ProposalDto;

namespace Teknosib.Business.Interface
{
    public interface IProposalService
    {
        Task<ResponseDto<List<ProposalDto>>> GetProposalListAsync();
        Task<ResponseDto<List<ProposalDto>>> GetProposalListWithStatusFalseAsync();
        Task<ResponseDto<ProposalDto>> GetByIdProposalAsync(Guid id);
        Task<ResponseDto<ProposalDto>> CreateProposalAsync(CreateProposalDto createProposalDto);
        Task<ResponseDto<UpdateProposalDto>> UpdateProposalAsync(Guid id, UpdateProposalDto updateProposalDto);
        Task<ResponseDto<object>> DeleteProposalAsync(DeleteProposalDto deleteProposalDto);
        Task<ResponseDto<object>> HardDeleteProposalAsync(DeleteProposalDto deleteProposalDto);
    }
}
