using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bll.interfaces;
using DAL.Interface;

namespace Bll.Concrete
{
    public class AuthManager : IAuthManager
    {
        private readonly IAdminDAL _AdminDAL;

        public AuthManager(IAdminDAL AdminDAL)
        {
            _AdminDAL = AdminDAL;
        }


        public bool Login(string username, string password)
        {
            return _AdminDAL.Login(username, password);


        }
    }
}

