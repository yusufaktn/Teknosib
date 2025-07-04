using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Interface;

namespace Teknosib.Business.Services
{
    public class AppUserManager : IAppUserService
    {
        public Task<List<AppUserDto>> GetAllUserAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AppUserDto> GetUserByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
