using BusinesLogic;
using DAL.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace BusinesLogic.Test
{
    [TestFixture]
    public class AuthManagerTests
    {
        private Mock<IUserDal> userDal;
        private AuthManager manager;

        [SetUp]
        public void Setup()
        {
            userDal = new Mock<IUserDal>(MockBehavior.Strict);

            manager = new AuthManager(userDal.Object);
        }


        [Test]
        public void LoginUserTest()
        {
            string username = "user";
            string password = "pass";

            userDal.Setup(d => d.Login(username, password)).Returns(true);
            var res = manager.Login(username, password);

            Assert.IsTrue(res);
        }

    }
}
