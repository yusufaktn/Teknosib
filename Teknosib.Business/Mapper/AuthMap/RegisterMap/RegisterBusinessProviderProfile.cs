using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.AuthDto.RegisterDto;
using Teknosib.Entity.Models;
using Teknosib.Entity.Models.Enums;

namespace Teknosib.Business.Mapper.AuthMap.RegisterMap
{
    public class RegisterBusinessProviderProfile:Profile
    {
        public RegisterBusinessProviderProfile()
        {
            CreateMap<RegisterBusinessProviderDto,AppUser>()
                .ForMember(x=>x.Role ,o=>o.MapFrom(y=>RoleTypes.BusinessProivder));

            CreateMap<RegisterBusinessProviderDto, LegalEntity>();
            CreateMap<RegisterBusinessProviderDto, BusinessProvider>();
        }
    }
}
