using RecipesAPI.Data;
using RecipesAPI.Repositories.GenericRepository;

namespace RecipesAPI.Services
{
    public interface IRecipeService : IGenericRepository<Recipe>
    {
      
    }
}