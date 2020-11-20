using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace Database.Interface
{
    public interface IRepositoryBase<T> where T:class,new()
    {
        T First(Expression<Func<T,bool>> Filter);
        T Find(Guid ID);
        IQueryable<T> Where(Expression<Func<T, bool>> Filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        bool Any(Expression<Func<T, bool>> Filter = null);
        int count(Expression<Func<T, bool>> Filter = null);
        IQueryable<TResult> Select<TResult>(Expression<Func<T, TResult>> Selector);
        IQueryable<TResult> Select<TResult>(Expression<Func<T, bool>> Filter,Expression<Func<T, TResult>> Selector);
        IEnumerable<T> GetAll();
        void CUDOperation(T Entity, EntityState State);
        int SaveChange();
    }
}
