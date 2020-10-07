using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data;
using RecipesAPI.Services;

namespace RecipesAPI.Web.Controllers
{
    [ApiController]
    public class RecipesController : Controller
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet("/api/recipes")]
        public ActionResult GetRecipes()
        {
            try
            {
                IEnumerable<Recipe> recipes = _recipeService.GetAll();

                if (recipes is null || !recipes.Any())
                    return new NotFoundResult();
                else
                    return Ok(recipes);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("/api/recipes/{id}")]
        public ActionResult GetRecipe(int id)
        {
            try
            {
                Recipe recipe = _recipeService.GetById(id);

                if (recipe is null)
                    return new NotFoundResult();
                else
                    return Ok(recipe);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("/api/recipes")]
        public ActionResult CreateRecipe([FromBody] Recipe recipe)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model State is Not Valid!!");

            try
            {
                _recipeService.Add(recipe);

                return Ok(recipe);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }

        [HttpDelete("/api/recipes/{id}")]
        public ActionResult DeleteRecipe(int id)
        {
            try
            {
                _recipeService.Delete(id);
                
                return Ok();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Deleting Book!!");
            }
            
        }

        [HttpPut("/api/recipes/{id}")]
        public ActionResult UpdateRecipe(int id, Recipe recipe)
        {
            if (id != recipe.RecipeId)
            {
                return BadRequest();
            }

            try
            {
                _recipeService.Update(recipe);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_recipeService.GetById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
    }
}