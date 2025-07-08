using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.LoginDto;
using Teknosib.Business.Dto.RegisterDto;

namespace Teknosib.Business.Interface
{
    public interface IAuthService
    {
        Task<string> RegisterBusinessAsync(RegisterBusinessProviderDto dto);
        Task<string> RegisterIndividualAsync(RegisterIndividualProviderDto dto);
        Task<string> RegisterCompanyAsync(RegisterCompanyDto dto);
        Task<string> LoginAsync(LoginDto dto);



    }
}
