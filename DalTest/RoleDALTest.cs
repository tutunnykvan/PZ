using DAL.Concrete;
using NUnit.Framework;
using System.EnterpriseServices;
using System.Linq;
using System.Configuration;
using DTO;
using System.Runtime.InteropServices;

namespace DAL.Tests
{
    [TestFixture]
    [Transaction(TransactionOption.RequiresNew), ComVisible(true)]
    public class RoleDALTest : ServicedComponent
    {
        public RoleDALTest()
        { }

        [Test]
        public void CreateTest()
        {
            RoleDAL dal = new RoleDAL(ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString);
            var result = dal.CreateRole(new RoleDTO
            {
                RoleName = "Адмін",
                Description="Може взаэмодіяти з юзерами",
                
            });
            Assert.IsTrue(result.RoleId != 0, "returned ID should be more than zero");
        }

        [Test]
        public void GetAllTest()
        {
            RoleDAL dal = new RoleDAL(ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString);
            var result = dal.CreateRole(new RoleDTO
            {
                RoleName = "User",
                Description = "може зайти на сайт",
            });
            var movies = dal.GetAllRole();
            Assert.AreEqual(0, movies.Count(x => x.RoleName == "User"));
        }

        [TearDown]
        public void Teardown()
        {
            if (ContextUtil.IsInTransaction)
            {
                ContextUtil.SetAbort();
            }
        }

    }
}
