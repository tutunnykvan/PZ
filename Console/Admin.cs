using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL.Concrete;
using System.Configuration;


namespace Console
{
    class Admin
    {
        AdminDAL dal = new AdminDAL(ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString);
        AdminDTO admin;
        public void UserDALMenu()
        {
            while (true)
            {
                System.Console.WriteLine("Welcome in Admin");
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
                        System.Console.WriteLine("Input Admin :");
                        admin = dal.CreateAdmin(new AdminDTO { });
                        System.Console.WriteLine("You add the: Id - " + admin.Id + " Email - " + admin.StartingWorking);
                        System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;
                    case "r":
                        System.Console.Write("Choose Id: ");
                        admin = dal.GetAdminById(System.Convert.ToInt32(System.Console.ReadLine()));
                        System.Console.WriteLine("You read the: Id - " + admin.Id + " StartingWorking - " + admin.StartingWorking);
                        System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;
                    case "rall":
                        List<AdminDTO> categories = dal.GetAllAdmin();
                        for (int i = 0; i < admin.Count; i++)
                        {
                            System.Console.WriteLine("Id - " + admin[i].Id + " Email - " + admin[i].StartingWorking);
                        }
                        System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;
                    case "u":
                        System.Console.WriteLine("Update StartingWorking:");
                        admin = dal.UpdateAdmin(new AdminDTO {  });
                        System.Console.WriteLine("You add the: Id - " + admin.Id + " StartingWorking - " + admin.StartingWorking);
                        System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;
                    case "d":
                        System.Console.WriteLine("Choose Id:");
                        dal.DeleteAdmin(System.Convert.ToInt32(System.Console.ReadLine()));
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

