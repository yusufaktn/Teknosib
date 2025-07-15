using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.AuthDto.LoginDto;
using Teknosib.Business.Dto.AuthDto.RegisterDto;


namespace Teknosib.Business.Interface
{
    public interface IAuthService
    {
        Task<ResponseDto<object>> RegisterUserAsync(RegisterUserDto dto);
        Task<ResponseDto<object>> RegisterIntitutionAsync(RegisterInstitutionDto dto);
        Task<ResponseDto<object>> RegisterCompanyAsync(RegisterCompanyDto dto);
        Task<ResponseDto<string>> LoginAsync(LoginDto dto);



    }
}
