using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data;

namespace RecipesAPI.Repositories.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly RecipesDB _context;
        private DbSet<T> table;
        public GenericRepository(RecipesDB context)
        {
            _context = context;
            table = _context.Set<T>();
        }
        public void Add(T obj)
        {
            table.Add(obj);
        }

        public T GetById(int id)
        {
            var result = table.Find(id);
            return result;
        }

        public IEnumerable<T> GetAll()
        {
            return table;
        }

        public void Delete(int id)
        {
            var result = table.Find(id);
            _context.Remove(result);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}