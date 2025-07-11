using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.AuthDto.LoginDto;
using Teknosib.Entity.Models;

namespace Teknosib.Business.Mapper.AuthMap.LoginMap
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {

            CreateMap<LoginDto, AppUser>()
                .ForMember(lg => lg.Email, x => x.MapFrom(c => c.Email));
                

        }
    }
}
