namespace RecipesAPI.Data.RequestModels
{
    public class RecipeRequest
    {
        public string RecipeName { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public int PrepareTime { get; set; }
        public int CookTime { get; set; }
        public string Steps { get; set; }
        public int [] Ingredients { get; set; }
   
    }
}