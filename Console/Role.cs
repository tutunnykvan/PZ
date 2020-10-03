using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL.Concrete;
using System.Configuration;


namespace Console
{
    class Role
    {
        RoleDAL dal = new RoleDAL(ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString);
        RoleDTO role;
        public void RoleDALMenu()
        {
            while (true)
            {
                System.Console.WriteLine("Welcome in Role");
                System.Console.WriteLine("c - Create");
                System.Console.WriteLine("r - read one");
                System.Console.WriteLine("rall - read all");
                System.Console.WriteLine("u - update");
                System.Console.WriteLine("d - delete");
                System.Console.WriteLine("else - exit");

                string a = System.Console.ReadLine();



                switch (a)
                {
                    case "c":
                        System.Console.WriteLine("Input RoleName:");
                        role = dal.CreateRole(new RoleDTO { RoleName = System.Console.ReadLine() });
                        System.Console.WriteLine("You add the: Id - " + role.RoleId + " Name - " + role.RoleName);
                        System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;
                    case "r":
                        System.Console.Write("Choose Id: ");
                        role = dal.GetRoleById(System.Convert.ToInt32(System.Console.ReadLine()));
                        System.Console.WriteLine("You read the: Id - " + role.RoleId + " Name - " + role.RoleName);
                        System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;
                    case "rall":
                        List<RoleDTO> categories = dal.GetAllRole();
                        for (int i = 0; i < role.Count; i++)
                        {
                            System.Console.WriteLine("Id - " + role[i].RoleId + " Name - " + role[i].RoleName);
                        }
                        System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;
                    case "u":
                        System.Console.WriteLine("Update Name:");
                        role = dal.UpdateRole(new RoleDTO { RoleName = System.Console.ReadLine() });
                        System.Console.WriteLine("You add the: Id - " + role.RoleId + " Name - " + role.RoleName);
                        System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;
                    case "d":
                        System.Console.WriteLine("Choose Id:");
                        dal.DeleteRole(System.Convert.ToInt32(System.Console.ReadLine()));
                        System.Console.WriteLine("Delete successful");
                        System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;
                    case "else":
                        break;

                }
            }

        }
    }
}

