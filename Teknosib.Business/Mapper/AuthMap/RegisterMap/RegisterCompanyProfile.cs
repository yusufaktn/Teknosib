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
    public class RegisterCompanyProfile : Profile
    {
        public RegisterCompanyProfile()
        {

            CreateMap<RegisterCompanyDto, AppUser>()
               .ForMember(x => x.Role, y => y.MapFrom(z => RoleTypes.Admin))
               .ForMember(x=>x.Name , y=>y.MapFrom(z=>z.AdminFirstName))
               .ForMember(x => x.Surname, y => y.MapFrom(z => z.AdminLastName))
               .ForMember(x => x.Email, y => y.MapFrom(z => z.AdminEmail));


            CreateMap<RegisterCompanyDto, Company>();
            CreateMap<RegisterCompanyDto, LegalEntity>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.CompanyName));

            CreateMap<RegisterCompanyDto, Address>();
                

        }
    }
}
