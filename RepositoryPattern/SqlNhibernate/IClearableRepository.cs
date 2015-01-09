using RepositoryPattern.Entities;
using RepositoryPattern.Entities.Interfaces;

namespace RepositoryPattern.SqlNhibernate
{
    public interface IClearableRepository<T> : IRepository<T> where T : Entity
    {
        void Clear();
    }
}