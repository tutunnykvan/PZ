using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRoleDAL
    {


        RoleDTO GetRoleById(int id);
        List<RoleDTO> GetAllRole();
        RoleDTO UpdateRole(RoleDTO role);
        RoleDTO CreateRole(RoleDTO role);
        void DeleteRole(int id);



    }
}
