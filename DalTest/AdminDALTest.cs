using DAL.Concrete;
using NUnit.Framework;
using System.EnterpriseServices;
using System.Linq;
using System.Configuration;
using DTO;
using System.Runtime.InteropServices;
using System;

namespace DAL.Tests
{
    [TestFixture]
    [Transaction(TransactionOption.RequiresNew), ComVisible(true)]
    public class AdminDALTest : ServicedComponent
    {
        public AdminDALTest()
        { }

        [Test]
        public void CreateTest()
        {
            DateTime date1 = new DateTime(2000, 7, 1);
            DateTime date2 = new DateTime(2000, 7, 1);
            AdminDAL dal = new AdminDAL(ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString);
            var result = dal.CreateAdmin(new AdminDTO
            {
                StartingWorking = date1,
                FinishingWorking = date2,
                PersonId = 18
            }) ;
            Assert.IsTrue(result.Id != 0, "returned ID should be more than zero");
        }

        [Test]
        public void GetAllTest()
        {
            DateTime date1 = new DateTime(2000, 7, 1);
            DateTime date2 = new DateTime(2000, 7, 1);
            AdminDAL dal = new AdminDAL(ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString);
            var result = dal.CreateAdmin(new AdminDTO
            {
                StartingWorking = date1,
                FinishingWorking = date2,
                PersonId = 18
            });
            var movies = dal.GetAllAdmin();
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