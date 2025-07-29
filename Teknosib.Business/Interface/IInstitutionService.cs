using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.CompanyDto;
using Teknosib.Business.Dto.InstitutionDto;

namespace Teknosib.Business.Interface
{
    public interface IInstitutionService
    {
        Task<ResponseDto<List<InstitutionDto>>> GetInstitutionListAsync();
        Task<ResponseDto<InstitutionDto>> GetInstitutionWithStatusFalseAsync();
        Task<ResponseDto<InstitutionDto>> GetByIdInstitutionAsync(Guid id);
        Task<ResponseDto<InstitutionDto>> CreateInstitutionAsync(CreateInstitutionDto createInstitutionDto);
        Task<ResponseDto<UpdateInstitutionDto>> UpdateInstitutionAsync(Guid id, UpdateInstitutionDto updateInstitutionDto);
        Task<ResponseDto<object>> DeleteInstitutionAsync(DeleteInstitutionDto deleteInstitutionDto);
        Task<ResponseDto<object>> HardDeleteInstitutionAsync(DeleteInstitutionDto deleteInstitutionDto);      
        Task<ResponseDto<InstitutionDto>> SaveInstitutionLogo(Guid institutionId, IFormFile formFile);
    }
}
