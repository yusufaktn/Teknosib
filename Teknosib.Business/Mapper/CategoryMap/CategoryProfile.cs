using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.CategoryDto;
using Teknosib.Entity.Models;

namespace Teknosib.Business.Mapper.CategoryMap
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<DeleteCategoryDto,Category>();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap().ForMember(dest=>dest.CategoryId,opt=>opt.Ignore());//Id değiştirlemez.
        }

    }
}
