using DAL.Concrete;
using NUnit.Framework;
using System.EnterpriseServices;
using System.Linq;
using System.Configuration;
using DTO;
using System.Runtime.InteropServices;
using System.Text;

namespace DAL.Tests
{
    [TestFixture]
    [Transaction(TransactionOption.RequiresNew), ComVisible(true)]
    public class UserDALTest : ServicedComponent
    {
        public UserDALTest()
        { }

        [Test]
        public void CreateTest()
        {
            UserDAL dal = new UserDAL(ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString);
            var result = dal.CreateUser(new UserDTO
            {
                Email = "ifusal.200@gmail.com",
                Password= Encoding.ASCII.GetBytes("123(hashed)"),
                PersonId =18

            });
            Assert.IsTrue(result.Id != 0, "returned ID should be more than zero");
        }

        [Test]
        public void GetAllTest()
        {
            UserDAL dal = new UserDAL(ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString);
            var result = dal.CreateUser(new UserDTO
            {
                Email = "ifusal.200@gmail.com",
                Password = Encoding.ASCII.GetBytes("123(hashed)"),
                PersonId = 18

            });
            var movies = dal.GetAllUser();
            Assert.IsTrue(result.Id != 0, "returned ID should be more than zero");
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
