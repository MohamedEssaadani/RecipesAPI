using System.ComponentModel.DataAnnotations;

namespace RecipesAPI.Data
{
    public class IngredientQuantity
    {
        [Key]
        private int QuantityId { get; set; }
        private Recipe Recipe { get; set; }
        private Ingredient Ingredient { get; set; }
        private int Qty { get; set; }
    }
}