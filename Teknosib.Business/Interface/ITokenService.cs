using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.TokenDto;
using Teknosib.Entity.Models;

namespace Teknosib.Business.Interface
{
    public interface ITokenService
    {
         TokensDto CreateTokens(AppUser user);
        
    }
}
