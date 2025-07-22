using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.SupportCallDto;
using Teknosib.Entity.Models;

namespace Teknosib.Business.Mapper.SupportCallMap
{
    public class SupportCallProfile : Profile
    {
        public SupportCallProfile()
        {
            //Output
            CreateMap<SupportCall, SupportCallDto>();

            //Input
            CreateMap<UpdateSupportCallDto, SupportCall>();
            CreateMap<CreateSupportCallDto, SupportCall>();
        }
    }
}
