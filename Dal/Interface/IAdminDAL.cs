using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
   public interface IAdminDAL
    {   
        AdminDTO GetAdminById(int id);
        List<AdminDTO> GetAllAdmin();
        AdminDTO UpdateAdmin(AdminDTO admin);
        AdminDTO CreateAdmin(AdminDTO admin);
        void DeleteAdmin(int id);
    }
}
