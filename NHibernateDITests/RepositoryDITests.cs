using System;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NHibernateDITests
{
    [TestClass]
    public class RepositoryDiTests
    {
        private readonly UnityContainer _container;

        public RepositoryDiTests()
        {
            _container = new UnityContainer();
            try
            {
                var transientLifetimeManager = new TransientLifetimeManager();
                InjectionMember[] injectionMembers = { };

                _container.RegisterType(typeof (IUserRepository), typeof (UserRepository), string.Empty,
                    transientLifetimeManager, injectionMembers);
            }
            catch (Exception exception)
            {
                var msg = exception.InnerException.Message;
                Console.Write(msg);
                throw;
            }

        }

        [TestMethod]
        public void Can_Create_UserRepository_Using_DependencyInjection()
        {
            var repo = _container.Resolve(typeof (IUserRepository));
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void Can_Save_User_By_UserRepository()
        {
            var repo = (IUserRepository) _container.Resolve(typeof(IUserRepository));
            var user = new User() {FirstName = "Rupesh", LastName = "Tiwari", Age = 32};
            repo.Save(user);

            var repo2 = (IUserRepository)_container.Resolve(typeof(IUserRepository));
            var users = repo.All();
            Assert.IsNotNull(users);
        }
    }


}
