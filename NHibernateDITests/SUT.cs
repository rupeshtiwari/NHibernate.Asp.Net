using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;

namespace NHibernateDITests
{
   
    public abstract class SessionFactory:IDisposable
    {
        private ISessionFactory _sessionFactory;

        public ISessionFactory CurrentSessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = CreateSessionFactory()); }
        }

        public abstract ISessionFactory CreateSessionFactory();
        public void Dispose()
        {
            
        }
    }

    public class NdemoSessionFactory : SessionFactory
    {
        private const string ConnectionString =
            @"Server = .\SQLEXPRESS; Integrated Security = SSPI; User ID=admin;Database= NDEMO";

        public override ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(ConnectionString)
                        .Dialect<MsSql2012Dialect>()
                        .Driver<Sql2008ClientDriver>()
                        .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RepositoryDiTests>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private void BuildSchema(Configuration config)
        {
            new SchemaUpdate(config).Execute(true, true);
        }
    }

    public class BaseSqlRepository<T, TC>
        where T : Entity
        where TC : SessionFactory
    {
        private readonly ISession _session;

        public BaseSqlRepository()
        {
            SessionFactory sessionFactory = Activator.CreateInstance<TC>();
            var sf = sessionFactory.CurrentSessionFactory;
            _session = sf.OpenSession();
        }

        protected IEnumerable<T> All(Expression<Func<T, bool>> expression)
        {
            return _session.Query<T>().Where(expression).ToList();
        }

        protected void Save(Expression<Func<T, bool>> expression, T t)
        {
            _session.SaveOrUpdate(t);
            _session.Flush();
            _session.Clear();
        }
    }

    public interface IUserRepository
    {
        IEnumerable<User> All();
        void Save(User user);
    }

    public class UserRepository : BaseSqlRepository<User, NdemoSessionFactory>, IUserRepository
    {
        public IEnumerable<User> All()
        {
            return All(x => x.FirstName == "Rupesh");
        }

        public void Save(User user)
        {
            Save(null, user);
        }
    }

    public class User : Entity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int Age { get; set; }
    }
    public class Entity
    {
        public virtual int Id { get; set; }
    }

    public class EntityMap : ClassMap<Entity>
    {
        public EntityMap()
        {
            DiscriminateSubClassesOnColumn("Type");
            Id(x => x.Id);
        }
    }

    public class UserMap : SubclassMap<User>
    {
        public UserMap()
        {
            KeyColumn("Id");
            Table("User");

            Map(d => d.FirstName);
            Map(d => d.LastName);
            Map(d => d.Age);
        }
    }
}

