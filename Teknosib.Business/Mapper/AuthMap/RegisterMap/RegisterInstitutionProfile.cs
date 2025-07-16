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
    public class RegisterInstitutionProfile : Profile
    {
        public RegisterInstitutionProfile()
        {
            CreateMap<RegisterInstitutionDto, AppUser>()
               .ForMember(x => x.Role, y => y.MapFrom(z => RoleTypes.Admin))
               .ForMember(x => x.Name, y => y.MapFrom(z => z.AdminFirstName))
               .ForMember(x => x.Surname, y => y.MapFrom(z => z.AdminLastName))
               .ForMember(x => x.Email, y => y.MapFrom(z => z.AdminEmail))
               .ForMember(x=>x.LegalEntity,y=>y.MapFrom(z=> new Institution
               {

                   Name = z.IntitutionName,
                   PhoneNumber = z.PhoneNumber,
                   Email = z.Email,
                   WebSite = z.WebSite,
                   Logo = z.Logo,

                   Type = z.Type,
                   OfficialTitle= z.OfficialTitle,
                   AuthorityName = z.AuthorityName,
                   AuthorityTitle= z.AuthorityTitle,
                   InstitutionCode = z.InstitutionCode,

                   Address = new Address
                   {
                       City = z.City,
                       District = z.District,
                       PostalCode = z.PostalCode,
                       AddressLine = z.AddressLine,
                       

                   }
               }));

            
               



        }
    }
}
