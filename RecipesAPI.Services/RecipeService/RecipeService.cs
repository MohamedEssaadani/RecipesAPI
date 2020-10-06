using System.Collections.Generic;
using RecipesAPI.Data;
using RecipesAPI.Repositories.GenericRepository;

namespace RecipesAPI.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly GenericRepository<Recipe> _repository;

        public RecipeService(GenericRepository<Recipe> repository)
        {
            _repository = repository;
        }
        
        public void Add(Recipe obj)
        {
            _repository.Add(obj);
        }

        public Recipe GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Recipe> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Recipe obj)
        {
            throw new System.NotImplementedException();
        }
    }
}