using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Yara.VoucherShop.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        protected DbContext _context;
        private IDbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T NewEntityInstance()
        {
            return _context.Set<T>().Create<T>();
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public int GetCount(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Count(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, int start, int count)
        {
            return _dbSet.Where(predicate).Skip(start).Take(count);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
