using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknosib.Business.Interface
{
    public interface IAppUserService
    {
        Task<List<AppUserDto>> GetAllUserAsync();
        Task<AppUserDto> GetUserByIdAsync(Guid id);



    }
}
