using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL
{
    public class BaseRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext Context;
        protected virtual IQueryable<T> BaseQuery => Context.Set<T>();

        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
        }
        public virtual void Add(T item)
        {
            Context.Add(item);
            Context.SaveChanges();
        }

        public virtual void Delete(T item)
        {
            Context.Remove(item);
            Context.SaveChanges();
        }

        public virtual void Update(T item)
        {
            Context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
        }

        public virtual IQueryable<T> GetAll()
        {
            return BaseQuery;
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public virtual T GetById(int id)
        {
            return BaseQuery.FirstOrDefault(t => t.Id == id);
        }
    }
}
