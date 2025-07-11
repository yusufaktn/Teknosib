using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.CategoryDto;
using Teknosib.Business.Interface;
using Teknosib.DataAccess.Repository.Repo;
using Teknosib.Entity.Models;

namespace Teknosib.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto<object>> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            try
            {
                var category = _mapper.Map<Category>(createCategoryDto);

                await _unitOfWork.Categories.AddAsync(category);
                await _unitOfWork.SaveChangesAsync();

                return ResponseDto<object>.Success("Kategori başarıyla eklendi", 200);
            }
            catch (Exception ex) 
            {
                return ResponseDto<object>.Fail("Kategori ekleme başarısız oldu -" + ex.Message, 500);                 
            }                 
        }

        public async Task<ResponseDto<object>> DeleteCategoryAsync(DeleteCategoryDto deleteCategoryDto)
        {
            try
            {
               var category= await _unitOfWork.Categories.GetByIdAsync(deleteCategoryDto.CategoryId);
                if(category is null)
                {
                    return ResponseDto<object>.Fail(deleteCategoryDto.CategoryId+"-Silnecek Kategori bulunamadı", 404);
                }
                await _unitOfWork.Categories.SoftDeleteAsync(category);
                await _unitOfWork.SaveChangesAsync();
                return ResponseDto<object>.Success(category.Name +" kategorisi silme başarılı", 200);

            }
            catch (Exception ex)
            {

                return ResponseDto<object>.Fail("Kategori silinirken bir hata oluştu"+ex.Message, 500);
            }
        }

        public async Task<ResponseDto<object>> GetByIdCategoryAsync(Guid id)
        {
            try
            {
                var category = await _unitOfWork.Categories.GetByIdAsync(id);
                if(category is null)
                {
                    return ResponseDto<object>.Fail(id + " Kategori bulunamadı", 404);
                }
                var categorydto= _mapper.Map<CategoryDto>(category);
                return ResponseDto<object>.Success(categorydto, 200);

            }
            catch (Exception ex) {
            
                return ResponseDto<object>.Fail("Kategori getirilirken bir hata oluştu"+ex.Message, 500);
            
            }


        }

        public async Task<ResponseDto<object>> GetCategoryAllAsync()
        {
            try
            {
                var get_category = await _unitOfWork.Categories.GetListAllAsync();
                if(get_category is null || !get_category.Any())
                {
                    return ResponseDto<object>.Fail("get_category boş değer!!", 404);
                }
                var dto_Category = _mapper.Map<List<CategoryDto>>(get_category);
                return ResponseDto<object>.Success(dto_Category, 200);
            }
            catch (Exception ex) 
            {
                return ResponseDto<object>.Fail("Kategoriler getirilirken bir hata oluştu", 500);
            }

        }

        public async Task<ResponseDto<object>> GetCategoryWithStatusFalseAsync()
        {
            try
            {
                var getcategory = await _unitOfWork.Categories.GetListIncludingStatusFalse();
                if (getcategory is null || !getcategory.Any())
                {
                    return ResponseDto<object>.Fail("Boş değer!!", 404);
                }

                var dto_category = _mapper.Map<List<CategoryDto>>(getcategory);
                return ResponseDto<object>.Success(dto_category, 200);

            }
            catch (Exception ex)
            {
                return ResponseDto<object>.Fail("Kategoriler getirilirken bir hata oluştu", 500);
            }
        }

        public async Task<ResponseDto<object>> HardDeleteCategoryAsync(DeleteCategoryDto hardDeleteCategoryDto)
        {
            try
            {
                var category_delete = await _unitOfWork.Categories.GetByIdAsync(hardDeleteCategoryDto.CategoryId);
                if(category_delete is null)
                {
                    return ResponseDto<object>.Fail("Silinecek kategori bulunamadı.", 404);
                }

                await _unitOfWork.Categories.HardDeleteAsync(category_delete);
                await _unitOfWork.SaveChangesAsync();
                return ResponseDto<object>.Success(category_delete.Name +" isimli kategori silme işlemi başarılı", 200);

            }
            catch(Exception ex)
            {
                return ResponseDto<object>.Fail("Kategori silinirken bir hata oluştu", 500);
            }
        }

        public async Task<ResponseDto<object>> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            try
            {
                var get_category = await _unitOfWork.Categories.GetByIdAsync(updateCategoryDto.CategoryId);
                if(get_category is null)
                {
                    return ResponseDto<object>.Fail("Güncellenecek kategori bulunamadı.",404);
                }

               var mapping_category= _mapper.Map(updateCategoryDto,get_category);
               await _unitOfWork.Categories.UpdateAsync(mapping_category);
               await _unitOfWork.SaveChangesAsync();

                return ResponseDto<object>.Success(updateCategoryDto+" Kategori başıryla güncellendi", 200);

            }
            catch(Exception ex)
            {
                return ResponseDto<object>.Fail("Kategori güncellenirken bir hata oluştu", 500);
            }


        }
    }
}
