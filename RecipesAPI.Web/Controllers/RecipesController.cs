using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data;
using RecipesAPI.Data.RequestModels;
using RecipesAPI.Services;

namespace RecipesAPI.Web.Controllers
{
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly ICategoryService _categoryService;

        public RecipesController(IRecipeService recipeService, ICategoryService categoryService)
        {
            _recipeService = recipeService;
            _categoryService = categoryService;
        }

        [HttpGet("/api/recipes")]
        public ActionResult GetRecipes()
        {
            IEnumerable<Recipe> recipes = _recipeService.GetAll();
            
            if(recipes == null || !recipes.Any())
                return NotFound("Not Recipes Found!");
                
            return Ok(recipes);
        }

        [HttpGet("/api/recipes/{id}")]
        public ActionResult GetRecipe(int id)
        {
            Recipe recipe = _recipeService.GetById(id);
            
            if(recipe == null )
                return NotFound($"No Recipe With ID : {id} Found!");

            return Ok(recipe);
        }

        [HttpPost("/api/recipes")]
        public ActionResult CreateRecipe([FromBody] RecipeRequest recipe)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model State is Not Valid!!");

            Category category = _categoryService.GetById(recipe.CategoryId);

            Recipe newRecipe = new Recipe
            {
                RecipeName = recipe.RecipeName, 
                Category = category, 
                Description = recipe.Description,
                CookTime = recipe.CookTime, 
                PrepareTime = recipe.PrepareTime, 
                Steps = recipe.Steps
            };
            
            _recipeService.Add(newRecipe);

            return Ok(newRecipe);
                
        }

        [HttpDelete("/api/recipes/{id}")]
        public ActionResult DeleteRecipe(int id)
        {
            Recipe recipe = _recipeService.GetById(id);
            
            if(recipe != null)
            {
                _recipeService.Delete(id);
                return Ok();
            }
            
            return NotFound($"No Recipe With ID : {id} Found!");
        }

        [HttpPut("/api/recipes/{id}")]
        public ActionResult UpdateRecipe(int id, Recipe recipe)
        {
            if (id != recipe.RecipeId || !ModelState.IsValid)
            {
                return BadRequest();
            }
            
            if (_recipeService.GetById(recipe.RecipeId) == null)
                return NotFound($"No Recipe With ID : {id} Found!");

            _recipeService.Update(recipe);
            
            return Ok();
        }
    }
}