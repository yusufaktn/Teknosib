using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.RegisterDto;
using Teknosib.Entity.Models;
using Teknosib.Entity.Models.Enums;

namespace Teknosib.Business.Mapper.Register
{
    public class RegisterBusinessProviderProfile:Profile
    {
        public RegisterBusinessProviderProfile()
        {
            CreateMap<RegisterBusinessProviderDto,AppUser>()
                .ForMember(x=>x.Role ,o=>o.MapFrom(y=>RoleTypes.BusinessProivder));

            CreateMap<RegisterBusinessProviderDto, SolutionProviderBase>();
            CreateMap<RegisterBusinessProviderDto, BusinessProvider>();
        }
    }
}
