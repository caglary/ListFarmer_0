using Database.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace Database.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        public EF.Context Context { get; set; }
        public DbSet<T> Table { get; set; }
        public RepositoryBase()
        {
            Context = new EF.Context();
            Table = Context.Set<T>();
        }
        public bool Any(Expression<Func<T, bool>> Filter = null)
        {
            return Filter==null?Table.Any(): Table.Any(Filter);
        }
        public int count(Expression<Func<T, bool>> Filter = null)
        {
            return Filter == null ? Table.Count() : Table.Count(Filter);
        }
        public void CUDOperation(T Entity, EntityState State)
        {
            Context.Entry(Entity).State = State;
        }
        public T Find(Guid ID)
        {
            return Table.Find(ID);
        }
        public T First(Expression<Func<T, bool>> Filter)
        {
            return Filter == null ? Table.First() : Table.First(Filter);
        }
        public IEnumerable<T> GetAll()
        {
            return Table.ToList();
        }
        public int SaveChange()
        {
            return Context.SaveChanges();
        }
        public IQueryable<TResult> Select<TResult>(Expression<Func<T, TResult>> Selector)
        {
            return Table.Select(Selector);
        }
        public IQueryable<TResult> Select<TResult>(Expression<Func<T, bool>> Filter, Expression<Func<T, TResult>> Selector)
        {
            return Table.Where(Filter).Select(Selector);
        }
        public IQueryable<T> Where(Expression<Func<T, bool>> Filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            return orderBy == null ? Table.Where(Filter) : orderBy(Table.Where(Filter));
        }
     
    }
}
