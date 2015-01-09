using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepositoryPattern.Entities.Interfaces
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        IEnumerable<T> All(Expression<Func<T, bool>> criteria);
    }
}