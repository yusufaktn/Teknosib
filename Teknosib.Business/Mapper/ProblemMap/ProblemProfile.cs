using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.ProblemDto;
using Teknosib.Entity.Models;

namespace Teknosib.Business.Mapper.ProblemMap
{
    public class ProblemProfile : Profile
    {
        public ProblemProfile()
        {
            // Giriş haritalamaları (Net ve tek yönlü)
            CreateMap<CreateProblemDto, Problem>();
            CreateMap<UpdateProblemDto, Problem>();
           

            // Çıkış haritalaması (Açık ve özel kurallı)
            CreateMap<Problem, ProblemDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName));



        }
    }
}
