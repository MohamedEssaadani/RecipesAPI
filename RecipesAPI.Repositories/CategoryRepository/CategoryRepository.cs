using RecipesAPI.Data;
using RecipesAPI.Repositories.GenericRepository;

namespace RecipesAPI.Repositories.CategoryRepository
{
    public class CategoryRepository:GenericRepository<Category>
    {
        public CategoryRepository(RecipesDB context) : base(context)
        {
        }
    }
}