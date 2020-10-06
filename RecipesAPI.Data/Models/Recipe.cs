using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipesAPI.Data
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public int PrepareTime { get; set; }
        public int CookTime { get; set; }
        public string Steps { get; set; }
        public ICollection<IngredientQuantity> Ingredients { get; set; }
        
    }
}