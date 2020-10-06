using System.ComponentModel.DataAnnotations;

namespace RecipesAPI.Data
{
    public class IngredientQuantity
    {
        [Key]
        public int QuantityId { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }
        public int Qty { get; set; }
    }
}