using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaAPI.Core.Application.Dtos;
using PruebaTecnicaAPI.Core.Application.Interfaces.Services;

namespace PruebaTecnicaAPI_SuperIntendenciaDeBancos.Controllers
{
    [ApiController]
    [Route("api/categories")]
    //[Authorize(Roles = "Admin")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            try
            {
                List<string> product = new List<string>() { "Products" };
                List<CategoryDto> categories = await categoryService.GetAllWithIncludeAsync(product);

                if (categories.Count <= 0) return NoContent();
                return Ok(categories);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        } 
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            try
            {
                CategoryDto category = await categoryService.GetByIdAsync(id);

                if (category == null) return NoContent();
                return Ok(category);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryCreateDto category)
        {
            try
            {
                if (category == null) return BadRequest();

                await categoryService.AddAsync(category);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }  
        
        [HttpPut]
        public async Task<IActionResult> Update(CategoryCreateDto category, int id)
        {
            try
            {
                if (category == null) return BadRequest();

                await categoryService.UpdateAsync(category, id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }  
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0) return BadRequest();

                await categoryService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }  
    }
}
