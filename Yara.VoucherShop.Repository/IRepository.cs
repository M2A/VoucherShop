using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Yara.VoucherShop.Repository
{
    public interface IRepository<T>
        where T : class
    {
        T NewEntityInstance();

        void Add(T item);

        void Remove(T item);

        T Get(Expression<Func<T, bool>> predicate);

        int GetCount(Expression<Func<T, bool>> predicate);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);

        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, int start, int count);

        void Save();

    }
}
