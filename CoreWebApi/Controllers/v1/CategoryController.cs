using System.Net.Http;
using System.Threading.Tasks;
using CoreWebApi.Contracts;
using CoreWebApi.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApi.Controllers.v1
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet(ApiRoutes.Category.GetAllCategories)]
        public async Task<IActionResult> GetCategories()
        {
            var model = await _categoryService.GetAllCategoriesAsync();

            return Ok(new
            {
                Success = true,
                Data = model
            });
        }

        [HttpGet(ApiRoutes.Category.GetCategoryById)]
        public async Task<IActionResult> GetCategoryById([FromRoute] int categoryId)
        {
            var model = await _categoryService.GetCategoryByIdAsync(categoryId);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                Success = true,
                Data = model
            });
        }
    }
}