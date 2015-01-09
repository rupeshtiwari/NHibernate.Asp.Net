using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
using RepositoryPattern.Entities;

namespace RepositoryPattern.SqlNhibernate
{
    public class NHibernateHelper
    {
        private readonly string _connectionString;
        private ISessionFactory _sessionFactory;

        public ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = CreateSessionFactory()); }
        }

        public NHibernateHelper(string connectionString=null)
        {
            _connectionString = connectionString ??
                                @"Server = .\SQLEXPRESS; Integrated Security = SSPI; User ID=admin;Database= NDEMO";
        }

        private ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(_connectionString)
                        .Dialect<MsSql2012Dialect>()
                        .Driver<Sql2008ClientDriver>()
                        .ShowSql())
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Segment>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private void BuildSchema(Configuration config)
        {
            new SchemaUpdate(config).Execute(true, true);
        }
    }
}
