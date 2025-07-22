using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.ProposalDto;
using Teknosib.Business.Dto.SupportCallDto;
using Teknosib.Entity.Models;

namespace Teknosib.Business.Interface
{
    public interface ISupportCallService
    {
        Task<ResponseDto<List<SupportCallDto>>> GetList_SupportCallAsync();
        Task<ResponseDto<List<SupportCallDto>>> GetListSupportCall_WithStatusFalseAsync();
        Task<ResponseDto<SupportCallDto>> GetById_SupportCallAsync(Guid id);
        Task<ResponseDto<SupportCallDto>> Create_SupportCallAsync(CreateSupportCallDto createSupportCallDto);
        Task<ResponseDto<UpdateSupportCallDto>> Update_SupportCallAsync(Guid id, UpdateSupportCallDto updateSupportCallDto);
        Task<ResponseDto<object>> Delete_SupportCallAsync(DeleteSupportCallDto deleteSupportCallDto);
        Task<ResponseDto<object>> HardDelete_SupportCallAsync(DeleteSupportCallDto deleteSupportCallDto);
    }
}
