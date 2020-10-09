using System.Collections.Generic;
using System.Linq;
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
            if(categories == null || !categories.Any())
                return NotFound("Not Categories Found!");
            
            return Ok(categories);
        }
        
        [HttpGet("/api/categories/{id}")]
        public ActionResult GetCategory(int id)
        {
            Category category = _categoryService.GetById(id);
            if(category == null )
                return NotFound($"No Category With ID : {id} Found!");
            return Ok(category);
        }
        
        [HttpPost("/api/categories")]
        public ActionResult CreateCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model State is Not Valid!!");

            _categoryService.Add(category);

            return Ok($"Category : {category.CategoryName} Added Successfully!");
        }

        [HttpDelete("/api/categories/{id}")]
        public ActionResult DeleteCategory(int id)
        {
            Category category = _categoryService.GetById(id);

            if (category != null)
            {
                _categoryService.Delete(id);
                return Ok($"Category with ID = {id} is Deleted Successfully.");
            }
            return NotFound($"No Category With ID : {id} Found!");
        }

        [HttpPut("/api/categories/{id}")]
        public ActionResult UpdateCategory(int id, Category category)
        {
            if (id != category.CategoryId || !ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_categoryService.GetById(category.CategoryId) == null)
                return NotFound($"No Category With ID : {id} Found!");
            
            _categoryService.Update(category);
            
            return Ok($"Updated Successfully.");
        }
    }
}