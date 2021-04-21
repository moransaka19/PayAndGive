using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext context;
        protected virtual IQueryable<T> baseQuery => context.Set<T>();

        public BaseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public virtual void Add(T item)
        {
            context.Add(item);
            context.SaveChanges();
        }

        public virtual void Delete(T item)
        {
            context.Remove(item);
            context.SaveChanges();
        }

        public virtual IQueryable<T> GetAll()
        {
            return baseQuery;
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public virtual T GetById(int id)
        {
            return baseQuery.Where(t => t.Id == id).FirstOrDefault();
        }
    }
}
