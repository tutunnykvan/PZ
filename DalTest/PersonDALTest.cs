using DAL.Concrete;
using NUnit.Framework;
using System.EnterpriseServices;
using System.Linq;
using System.Configuration;
using DTO;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System;

namespace DAL.Tests
{
    [TestFixture]
    [Transaction(TransactionOption.RequiresNew), ComVisible(true)]
    public class PersonDALTest : ServicedComponent
    {
        public PersonDALTest()
        { }

        [Test]
        public void CreateTest()
        {DateTime date = new DateTime(2000, 7, 1);
            PersonDAL dal = new PersonDAL(ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString);
            var result = dal.CreatePerson(new PersonDTO
            {
                FirstName = "Ivan",
                LastName = "Husak",
                Birthday = date,
                RoleId=13
            });
            Assert.IsTrue(result.PersonId != 0, "returned ID should be more than zero");
        }

        [Test]
        public void GetAllTest()
        {
        DateTime date = new DateTime(2000, 7, 1);
            PersonDAL dal = new PersonDAL(ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString);
        var result = dal.CreatePerson(new PersonDTO
        {
            FirstName = "Ivan",
            LastName = "Husak",
            Birthday = date,
            RoleId=13
        }); ;
            var movies = dal.GetAllPerson();
            Assert.IsTrue(result.PersonId != 0, "returned ID should be more than zero");
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
