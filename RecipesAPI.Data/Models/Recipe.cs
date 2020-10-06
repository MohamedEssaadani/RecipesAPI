using System;
using System.Collections.Generic;

namespace RecipesAPI.Data
{
    public class Recipe
    {
        private int RecipeId { get; set; }
        private string RecipeName { get; set; }
        private Category Category { get; set; }
        private string Description { get; set; }
        private int PrepareTime { get; set; }
        private int CookTime { get; set; }
        private string Steps { get; set; }
        private ICollection<IngredientQuantity> Ingredients { get; set; }
        
    }
}