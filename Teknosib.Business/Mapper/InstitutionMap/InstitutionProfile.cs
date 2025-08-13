using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.InstitutionDto;
using Teknosib.Entity.Models;

namespace Teknosib.Business.Mapper.InstitutionMap
{
    public class InstitutionProfile : Profile
    {
        public InstitutionProfile()
        {
            //Output
            CreateMap<Institution, InstitutionDto>().ForMember(x => x.InstitutionName, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.ApproveStatus, y => y.MapFrom(z => z.AproveStatus)); ;
            //Input
            CreateMap<UpdateInstitutionDto, Institution>().ForMember(x => x.Name, y => y.MapFrom(z => z.InstitutionName))
                .ForMember(x => x.AproveStatus, y => y.MapFrom(z => z.ApproveStatus)); ;
            CreateMap<CreateInstitutionDto, Institution>().ForMember(x => x.Name, y => y.MapFrom(z => z.InstitutionName));

        }
    }
}
