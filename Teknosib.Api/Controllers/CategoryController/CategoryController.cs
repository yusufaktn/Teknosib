using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teknosib.Business.Dto.CategoryDto;
using Teknosib.Business.Interface;

namespace Teknosib.Api.Controllers.CategoryController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            
            var response = await _categoryService.GetCategoryAllAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }

           return  BadRequest(response);


        }

        [HttpGet("GetAllCategory_WithFalse")]
        [Authorize(Roles= "SuperAdmin")]
        public async Task<IActionResult> GetAllCategoryWithStatusFalse()
        {

            var response = await _categoryService.GetCategoryAllAsync(true);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }

        [HttpGet("GetByIdCategory")]
        public async Task<IActionResult> GetByIdCategory(Guid id)
        {
            var response = await _categoryService.GetByIdCategoryAsync(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }



        [HttpPost("CreateCategory")]
        [Authorize(Roles = "SuperAdmin")]

        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {

            var response = await _categoryService.CreateCategoryAsync(createCategoryDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }


        [HttpDelete("DeleteCategory")]
        [Authorize(Roles ="SuperAdmin")]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryDto deleteCategoryDto) 
        {
            var response = await _categoryService.DeleteCategoryAsync(deleteCategoryDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }

        [HttpPut("UpdateCategory")]
        [Authorize(Roles ="SuperAdmin")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var response = await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("HardDeleteCategory")]
        [Authorize(Roles ="SuperAdmin")]

        public async Task<IActionResult> HardDeleteCategory(DeleteCategoryDto hardDeleteCategoryDto)
        {

            var response = await _categoryService.HardDeleteCategoryAsync(hardDeleteCategoryDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }




    }
}
