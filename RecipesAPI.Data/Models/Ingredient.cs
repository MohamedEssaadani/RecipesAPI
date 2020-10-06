using System.ComponentModel.DataAnnotations;

namespace RecipesAPI.Data
{
    public class Ingredient
    {
        [Key]
        private int IngredientId { get; set; }
        private string IngredientName { get; set; }
    }
}