using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrovTHA.Models;
using TrovTHA.Repository;

namespace TrovTHA.Tests.Repository
{
    [TestClass]
    public class UserRepositoryTest
    {
        [TestMethod]
        public void TestSaveAndFindAll()
        {
            IUserRepository repository = new UserRepository();

            repository.Save(new ApplicationUser {Email = "dummy@email.com", DomainId = "1", UserName = "dummy"});
            var result = repository.FindAll().ToList();

            Assert.AreEqual(1, result.Count);


            var dummy = result.FirstOrDefault(item => item.Email == "dummy@email.com");
            Assert.IsNotNull(dummy);
        }

        [TestMethod]
        public void TestSaveAndFindById()
        {
            IUserRepository repository = new UserRepository();

            repository.Save(new ApplicationUser { Email = "dummy@email.com", DomainId = "1", UserName = "dummy" });

            var dummy = repository.FindById("1");
            Assert.IsNotNull(dummy);
        }

        [TestMethod]
        public void TestSaveAndFindByUsername()
        {
            IUserRepository repository = new UserRepository();

            repository.Save(new ApplicationUser { Email = "dummy@email.com", DomainId = "1", UserName = "dummy" });

            var dummy = repository.FindByUsername("dummy");
            Assert.IsNotNull(dummy);
        }

        [TestMethod]
        public void ShouldNotFindByUsername()
        {
            IUserRepository repository = new UserRepository();
            var dummy = repository.FindByUsername("dummy");
            Assert.IsNull(dummy);
        }

    }
}
