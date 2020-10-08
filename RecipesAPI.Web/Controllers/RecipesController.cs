using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data;
using RecipesAPI.Services;

namespace RecipesAPI.Web.Controllers
{
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
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
        public ActionResult CreateRecipe([FromBody] Recipe recipe)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model State is Not Valid!!");
            
            _recipeService.Add(recipe);

            return Ok(recipe);
                
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