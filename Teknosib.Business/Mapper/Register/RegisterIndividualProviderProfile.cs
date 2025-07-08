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
    public class RegisterIndividualProviderProfile: Profile
    {
        public RegisterIndividualProviderProfile()
        {
            CreateMap<RegisterIndividualProviderDto, AppUser>()
                .ForMember(x => x.Role, o => o.MapFrom(y => RoleTypes.IndividualProvider));

            CreateMap<RegisterIndividualProviderDto, SolutionProviderBase>();
            CreateMap<RegisterIndividualProviderDto, IndividualProvider>();

        }
    }
}
