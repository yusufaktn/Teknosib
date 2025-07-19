using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.CompanyDto;

namespace Teknosib.Business.Interface
{
    public interface ICompanyService
    {
        Task<ResponseDto<List<CompanyDto>>> GetCompanyListAsync();
        Task<ResponseDto<CompanyDto>> GetCompanyWithStatusFalseAsync();
        Task<ResponseDto<CompanyDto>> GetByIdCompanyAsync(Guid id);
        Task<ResponseDto<CompanyDto>> CreateCompanyAsync(CreateCompanyDto createCompanyDto);
        Task<ResponseDto<UpdateCompanyDto>> UpdateCompanyAsync(Guid id ,UpdateCompanyDto updateCompanyDto);
        Task<ResponseDto<object>> DeleteCompanyAsync(DeleteCompanyDto deleteCompanyDto);
        Task<ResponseDto<object>> HardDeleteAsync(DeleteCompanyDto deleteCompanyDto);

    }
}
