using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Context;
using NHibernate.Linq;
using RepositoryPattern.Entities;

namespace RepositoryPattern.SqlNhibernate
{
    public abstract class BaseSqlRepository<T> : IClearableRepository<T>
        where T : Entity
    {
        private readonly ISession _session;

        protected BaseSqlRepository(ISession session)
        {
            _session = session;
        }

        public bool SaveOrUpdate(Expression<Func<T, bool>> expression, T entity)
        {
            if (_session.Query<T>().Where(expression).Any())
            {
                _session.SaveOrUpdate(entity);
            }
            else
            {
                _session.Save(entity);
            }
            _session.Flush();
            _session.Clear();
            return true;
        }

        public bool Delete(T entity)
        {
            _session.Delete(entity);
            return true;
        }
    
        protected T Get(Expression<Func<T, bool>> expression)
        {
            return _session.Query<T>().Where(expression).SingleOrDefault();
        }

        public IEnumerable<T> All(Expression<Func<T, bool>> expression)
        {
            return _session.Query<T>().Where(expression).ToList();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (_session != null)
                _session.Dispose();
        }
    }
}