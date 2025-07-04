using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknosib.Business.Interface
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto categorydto);

    }
}
