using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RecipesAPI.Data;
using RecipesAPI.Services;

namespace RecipesAPI.Web.Controllers
{
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("/api/categories")]
        public ActionResult GetCategories()
        {
            IEnumerable<Category> categories = _categoryService.GetAll();

            return Ok(categories);
        }
        
        [HttpGet("/api/categories/{id}")]
        public ActionResult GetCategory(int id)
        {
            Category category = _categoryService.GetById(id);
        
            return Ok(category);
        }
        
        [HttpPost("/api/categories")]
        public ActionResult CreateCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model State is Not Valid!!");

            _categoryService.Add(category);

            return Ok();
        }

        [HttpDelete("/api/categories/{id}")]
        public ActionResult DeleteCategory(int id)
        {
            _categoryService.Delete(id);
            
            return Ok();
        }

        [HttpPut("/api/categories/{id}")]
        public ActionResult UpdateCategory(int id, Category category)
        {
            if (id != category.CategoryId || !ModelState.IsValid)
            {
                return BadRequest();
            }
            
            _categoryService.Update(category);

            return Ok();
        }
    }
}