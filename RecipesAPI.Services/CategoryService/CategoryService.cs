using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data;
using RecipesAPI.Repositories.GenericRepository;

namespace RecipesAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _repository;

        public CategoryService(IGenericRepository<Category> repository)
        {
            _repository = repository;
        }
        
        public void Add(Category obj)
        {
            _repository.Add(obj);
            Save();
        }

        public Category GetById(int id)
        {
            Category category = _repository.GetById(id);

            return category;
        }

        public IEnumerable<Category> GetAll()
        {
            IEnumerable<Category> categories = _repository.GetAll();
            
            return categories;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
          Save();

        }

        public  void Update(Category obj)
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