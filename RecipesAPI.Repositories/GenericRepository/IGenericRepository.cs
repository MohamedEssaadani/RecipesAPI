using System.Collections;
using System.Collections.Generic;

namespace RecipesAPI.Repositories.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        public void Add(T obj);
        public T GetById(int id);
        public IEnumerable<T> GetAll();
        public void Delete(int id);
        public void Update(T obj);
    }
}