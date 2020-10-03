using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;

namespace DAL.Interface
{
   public interface IUserDAL
    {

        UserDTO GetUserById(int id);
        List<UserDTO> GetAllUser();
        UserDTO UpdateUser(UserDTO user);
        UserDTO CreateUser(UserDTO user);
        void DeleteUser(int id);

    }
}
