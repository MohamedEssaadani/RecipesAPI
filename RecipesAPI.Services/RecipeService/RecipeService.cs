using System;
using System.Collections.Generic;
using RecipesAPI.Data;
using RecipesAPI.Repositories.GenericRepository;

namespace RecipesAPI.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IGenericRepository<Recipe> _repository;

        public RecipeService(IGenericRepository<Recipe> repository)
        {
            _repository = repository;
        }
        
        public void Add(Recipe obj)
        {
            _repository.Add(obj);
            Save();
        }

        public Recipe GetById(int id)
        {
           var recipe = _repository.GetById(id);

           if (recipe != null)
               return recipe;
           else
               throw new InvalidOperationException($"There is no recipe with ID :{id} ");
        }

        public IEnumerable<Recipe> GetAll()
        {
            return _repository.GetAll();
        }

        public void Delete(int id)
        {
            var recipe = _repository.GetById(id);
            
            if (recipe != null)
            {
                _repository.Delete(id);
                Save();
            }
            else
                throw new InvalidOperationException($"There is no recipe with  ID :{id} ");

        }

        public void Update(Recipe obj)
        {
           _repository.Update(obj);
          Save();
        }

        public void Save()
        {
            _repository.Save();
        }
    }
}