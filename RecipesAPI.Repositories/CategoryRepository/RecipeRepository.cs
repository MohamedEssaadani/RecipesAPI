using RecipesAPI.Data;
using RecipesAPI.Repositories.GenericRepository;

namespace RecipesAPI.Repositories.CategoryRepository
{
    public class RecipeRepository : GenericRepository<Recipe>
    {
        public RecipeRepository(RecipesDB context) : base(context)
        {
            
        }
    }
    
}