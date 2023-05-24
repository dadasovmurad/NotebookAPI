using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost("add")]
        public IActionResult Add(Category category)
        {
            return Ok(_categoryService.Add(category));
        }
        [HttpGet("getall")]
        public IActionResult GetCategories()
        {
            return Ok(_categoryService.GetCategories());
        }
        [HttpGet("getnames")]
        public IActionResult GetCategoryNames()
        {
            return Ok(_categoryService.GetCategoryNames());
        }
    }
}
