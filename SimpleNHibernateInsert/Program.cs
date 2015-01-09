using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;

namespace ConsoleApplication1
{
    public class User 
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

    }

    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var sessionFactory = CreateSessionFactory();
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var user = new User() {FirstName = "Rupesh", LastName = "Tiwari"};
                session.SaveOrUpdate(user);
                transaction.Commit();
            }
            Console.ReadLine();
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012.ConnectionString(
                        @"Server = .\SQLEXPRESS; Integrated Security = SSPI; User ID=admin;
Database= NDEMO")
                        .Dialect<MsSql2012Dialect>()
                        .Driver<Sql2008ClientDriver>().ShowSql())
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<User>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            new SchemaUpdate(config).Execute(true, true);
        }

        public static string DbFile = @"C:/Program Files/Microsoft SQL Server/MSSQL11.SQLEXPRESS/MSSQL/DATA/NDEMO.mdf";
    }
}