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
    public class RegisterIndividualProviderProfile: Profile
    {
        public RegisterIndividualProviderProfile()
        {
            CreateMap<RegisterIndividualProviderDto, AppUser>()
                .ForMember(x => x.Role, o => o.MapFrom(y => RoleTypes.IndividualProvider));

            CreateMap<RegisterIndividualProviderDto, LegalEntity>();
            CreateMap<RegisterIndividualProviderDto, IndividualProvider>();

        }
    }
}
