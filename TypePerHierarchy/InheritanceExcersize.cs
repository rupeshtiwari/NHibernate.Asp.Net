using System;
using System.Linq;
using Iesi.Collections.Generic;
using JetBrains.Annotations;
using NHibernate.Linq;
using RepositoryPattern.Entities;

namespace InHeritance
{
    class InheritanceExcersize
    {
        public static void InsertNewSnake(NHibernateHelper helper)
        {
            using (var session = helper.SessionFactory.OpenSession())
            {
                var txn = session.BeginTransaction();
                var snake = new Snake {Length = 3, Family = "oooo"};
                session.SaveOrUpdate(snake);
                txn.Commit();
            }
        }

        public static void InsertNewDog(NHibernateHelper helper)
        {
            using (var session = helper.SessionFactory.OpenSession())
            {
                var txn = session.BeginTransaction();

                var dogid = new DogId(Guid.NewGuid().ToString());

                var dog = new Dog(dogid) {Breed = "Japanees", Family = "Nice" };

                session.SaveOrUpdate(dog);

                txn.Commit();
            }
        }

        public static void UpdateSnake(NHibernateHelper helper)
        {
            using (var session = helper.SessionFactory.OpenSession())
            {
                var txn = session.BeginTransaction();
                var found = session.Query<Snake>().FirstOrDefault(x => x.Family == "oooo");
                found.Length = 85;
                session.SaveOrUpdate(found);
                txn.Commit();
            }
        }

        public static void InsertNewPerson(NHibernateHelper helper)
        {
            using (var session = helper.SessionFactory.OpenSession())
            {
                var txn = session.BeginTransaction();
                var person = new Person()
                {
                    Address = new Address {City = "NB", State = "NJ", Street = "PD"},
                    FirstName = "R",
                    LastName = "T"
                };

                session.SaveOrUpdate(person);
                txn.Commit();
            }

        }

        public static void InsertTestletSegment(NHibernateHelper helper)
        {
            var testletId = new TestletId(Guid.NewGuid().ToString());
            using (var session = helper.SessionFactory.OpenSession())
            {
                var txn = session.BeginTransaction();
                var testlet = new TestletSegment
                {
                    TestletCounts = "3",
                    SegmentName = "Testlets",
                    TestletId = testletId,
                    Items =
                        new HashedSet<Item>
                        {
                            new Item {Name = "t", Type = "type1"},
                            new Item {Name = "t1", Type = "type2"},
                            new Item {Name = "t2", Type = "type13"}
                        }
                };

                session.SaveOrUpdate(testlet);
                txn.Commit();
            }

            using (var session = helper.SessionFactory.OpenSession())
            {
                var txn = session.BeginTransaction();

                var testlet = session.Query<TestletSegment>().SingleOrDefault(x => x.TestletId.TestletGuid==testletId.TestletGuid);
                 
                
                txn.Commit();
            }

        }
    }
}
