using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.CategoryDto;
using Teknosib.Business.Dto.SharedDto;

namespace Teknosib.Business.Interface
{
    public interface ICategoryService
    {
        Task<ResponseDto<object>> GetCategoryAllAsync(bool status=false);
        Task<ResponseDto<object>> GetByIdCategoryAsync(Guid id);
        Task<ResponseDto<object>> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task<ResponseDto<object>> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task<ResponseDto<object>> DeleteCategoryAsync(DeleteCategoryDto deleteCategoryDto);
        Task<ResponseDto<object>> HardDeleteCategoryAsync(DeleteCategoryDto hardDeleteCategoryDto);


    }
}
