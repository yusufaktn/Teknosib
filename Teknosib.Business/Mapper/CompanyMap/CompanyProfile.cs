using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.CompanyDto;
using Teknosib.Entity.Models;

namespace Teknosib.Business.Mapper.CompanyMap
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(x => x.CompanyName, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.ApproveStatus, y => y.MapFrom(z => z.AproveStatus));



            CreateMap<CreateCompanyDto, Company>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.CompanyName));
                
            CreateMap<UpdateCompanyDto, Company>().ForMember(x => x.AproveStatus, y => y.MapFrom(z => z.ApproveStatus)); ;

        }
    }
}
