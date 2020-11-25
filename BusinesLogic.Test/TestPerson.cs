using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using Moq;
using Bll.Concrete;
using DAL.Interface;
using DTO;


namespace BusinessLogic.Tests
{
    [TestFixture]
    public class PersonManagerTests
    {
     
        private Mock<IPersonDAL> personDal;
        private PersonManager person;

        [SetUp]
        public void Setup()
        {
           personDal = new Mock<IPersonDAL>(MockBehavior.Strict);

            person = new PersonManager(personDal.Object);
        }


        [Test]
        public void AddPersonTest()
        { 

            PersonDTO inMovie = new PersonDTO
            {
                FirstName = "Ivan",
                LastName = "Husak",
                Birthday = new DateTime(2000, 7, 1),
                RoleId = 13
            };
            PersonDTO outMovie = new PersonDTO { PersonId = 1 };

            personDal.Setup(d => d.CreatePerson(inMovie)).Returns(outMovie);
            var res = person.AddPerson(inMovie);

            Assert.IsNotNull(res);
            Assert.AreEqual(outMovie.PersonId, res.PersonId);
        }
    }
}
