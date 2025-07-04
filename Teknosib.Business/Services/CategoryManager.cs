using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Interface;

namespace Teknosib.Business.Services
{
    public class CategoryManager : ICategoryService
    {

        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task CreateCategoryAsync(CreateCategoryDto categorydto)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryDto>> GetAllCategoryAsync()
        {
            throw new NotImplementedException();
        }
    }
}
