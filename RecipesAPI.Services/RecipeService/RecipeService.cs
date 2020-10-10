using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
            Recipe recipe = _repository.GetById(id);

           if (recipe != null)
               return recipe;
           else
               throw new InvalidOperationException($"No Recipe Found With ID :{id} ");
        }

        public IEnumerable<Recipe> GetAll()
        {
            IEnumerable<Recipe> recipes = _repository.GetAll();

            if (recipes is null || !recipes.Any())
                throw new InvalidOperationException($"No Recipes Found!");
            else
                return recipes;

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
                throw new InvalidOperationException($"No Recipe Found With ID :{id} ");

        }

        public void Update(Recipe obj)
        {
            try
            {
                _repository.Update(obj);
                Save();
            }
            catch (DbUpdateException)
            {
             
                if (_repository.GetById(obj.RecipeId) == null)
                {
                    throw new InvalidOperationException($"No Recipe Found With ID :{obj.RecipeId} ");
                }
                else
                {
                    throw;
                }
            }
        }

        public void Save()
        {
            _repository.Save();
        }
    }
}