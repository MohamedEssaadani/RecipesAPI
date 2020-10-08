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
            try
            {
               _repository.Add(obj);
               Save();
            }
            catch (Exception)
            {
                throw new InvalidCastException("Error while Creating New Category!!");
            }
        }

        public Category GetById(int id)
        {
            Category category = _repository.GetById(id);

            if (category != null)
                return category;
            else
                throw new InvalidOperationException($"No Category Found With ID :{id} ");

        }

        public IEnumerable<Category> GetAll()
        {
            IEnumerable<Category> categories = _repository.GetAll();

            if (categories is null || !categories.Any())
                throw new InvalidOperationException("No Categories Found!");
            else 
                return categories;
        }

        public void Delete(int id)
        {
            Category category = _repository.GetById(id);

            if (category != null)
            { 
                _repository.Delete(id);
                Save();
            }else
                throw new InvalidOperationException($"No Category Found With ID : {id}");


        }

        public void Update(Category obj)
        {
            try
            {
                _repository.Update(obj);
                Save();
            }
            catch (DbUpdateException)
            {
             
                if (_repository.GetById(obj.CategoryId) == null)
                {
                    throw new InvalidOperationException($"No Recipe Found With ID :{obj.CategoryId} ");
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