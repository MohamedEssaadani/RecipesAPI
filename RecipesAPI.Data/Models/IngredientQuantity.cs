namespace RecipesAPI.Data
{
    public class IngredientQuantity
    {
        private int QuantityId { get; set; }
        private Recipe Recipe { get; set; }
        private Ingredient Ingredient { get; set; }
        private int Qty { get; set; }
    }
}