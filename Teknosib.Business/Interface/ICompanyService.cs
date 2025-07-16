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
        Task<ResponseDto<CompanyDto>> GetCompanyListAsync();
        Task<ResponseDto<CompanyDto>> GetCompanyWithStatusFalseAsync();
        Task<ResponseDto<CompanyDto>> GetByIdCompanyAsync();
        Task<ResponseDto<CompanyDto>> CreateCompanyAsync(CreateCompanyDto createCompanyDto);
        Task<ResponseDto<CompanyDto>> UpdateCompanyAsync();
        Task<ResponseDto<object>> DeleteCompanyAsync();
        Task<ResponseDto<object>> HardDeleteAsync();

    }
}
