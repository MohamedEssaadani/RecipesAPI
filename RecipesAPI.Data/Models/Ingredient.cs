using System.ComponentModel.DataAnnotations;

namespace RecipesAPI.Data
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
    }
}