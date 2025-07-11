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
            // ÇIKIŞ (OUTPUT) MAPPING: Entity'den DTO'ya
            // Veritabanından okunan Category nesnesini istemciye göndermek için.
            CreateMap<Category, CategoryDto>();

            // GİRİŞ (INPUT) MAPPINGS: DTO'dan Entity'ye
            // Yeni bir kategori oluşturmak için.
            CreateMap<CreateCategoryDto, Category>();

            // Var olan bir kategoriyi güncellemek için.
            CreateMap<UpdateCategoryDto, Category>()
                .ForMember(dest => dest.CategoryId, opt => opt.Ignore()); // Harika kullanım! ID'yi asla güncelleme.
        }

    }
}
