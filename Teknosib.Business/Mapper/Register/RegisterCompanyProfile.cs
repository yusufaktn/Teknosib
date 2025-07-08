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
    public class RegisterCompanyProfile : Profile
    {
        public RegisterCompanyProfile()
        {

            CreateMap<RegisterCompanyDto, AppUser>()
               .ForMember(x => x.Role, y => y.MapFrom(z => RoleTypes.Company));

            CreateMap<RegisterCompanyDto, Company>();
                

        }
    }
}
