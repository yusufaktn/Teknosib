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
    public class RegeisterUserProfile : Profile
    {
        public RegeisterUserProfile()
        {
            CreateMap<RegisterUserDto, AppUser>()
             .ForMember(x => x.Role, y => y.MapFrom(z => RoleTypes.User));

        }
    }
}
