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

namespace BusinesLogic.Test
{
    
        
    
        [TestFixture]
        public class AuthManagerTests
        {
            private Mock<IAdminDAL> adminDal;
            private AuthManager manager;

            [SetUp]
            public void Setup()
            {
                adminDal = new Mock<IAdminDAL>(MockBehavior.Strict);

                manager = new AuthManager(adminDal.Object);
            }


            [Test]
        public void LoginUserTest()
            {
                string username = "user";
                string password = "pass";

                adminDal.Setup(d => d.Login(username, password)).Returns(true);
                var res = manager.Login(username, password);

                Assert.IsTrue(res);
            }
        }
    
   
}

