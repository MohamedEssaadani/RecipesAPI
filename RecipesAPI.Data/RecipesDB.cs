
using Microsoft.EntityFrameworkCore;

namespace RecipesAPI.Data
{
    public class RecipesDB : DbContext
    {
        public RecipesDB() : base()
        {
            
        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<IngredientQuantity> Quantities { get; set; }

    }
}