using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.Category;
using Teknosib.Entity.Models;

namespace Teknosib.Business.Mapper
{
    public class CategoryProfile: Profile 
    {
        public CategoryProfile()
        {

            CreateMap<CategoryDto, Category>();

        }

    }
}
