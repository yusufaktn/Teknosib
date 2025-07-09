using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.LoginDto;
using Teknosib.Business.Dto.RegisterDto;
using Teknosib.Business.Dto.SharedDto;

namespace Teknosib.Business.Interface
{
    public interface IAuthService
    {
        Task<ResponseDto<object>> RegisterBusinessAsync(RegisterBusinessProviderDto dto);
        Task<ResponseDto<object>> RegisterIndividualAsync(RegisterIndividualProviderDto dto);
        Task<ResponseDto<object>> RegisterCompanyAsync(RegisterCompanyDto dto);
        Task<ResponseDto<string>> LoginAsync(LoginDto dto);



    }
}
