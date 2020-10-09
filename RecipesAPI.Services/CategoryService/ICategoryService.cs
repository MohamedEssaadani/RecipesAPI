using RecipesAPI.Data;
using RecipesAPI.Repositories.GenericRepository;

namespace RecipesAPI.Services
{
    public interface ICategoryService : IGenericRepository<Category>
    {
        
    }
}