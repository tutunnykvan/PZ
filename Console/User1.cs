using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL.Concrete;
using System.Configuration;


namespace Console
{
    class User
    {
        UserDAL dal = new UserDAL(ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString);
        UserDTO user;
        public void UserDALMenu()
        {
            while (true)
            {
                System.Console.WriteLine("Welcome in User");
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
                        System.Console.WriteLine("Input User :");
                        user = dal.CreateUser(new UserDTO { Email = System.Console.ReadLine() });
                        System.Console.WriteLine("You add the: Id - " + user.Id + " Email - " + user.Email);
                        System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;
                    case "r":
                        System.Console.Write("Choose Id: ");
                        user = dal.GetUserById(System.Convert.ToInt32(System.Console.ReadLine()));
                        System.Console.WriteLine("You read the: Id - " + user.Id + " Email - " + user.Email);
                        System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;
                    case "rall":
                        List<UserDTO> categories = dal.GetAllUser();
                        for (int i = 0; i < user.Count; i++)
                        {
                            System.Console.WriteLine("Id - " + user[i].Id + " Email - " + user[i].Email);
                        }
                        System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;
                    case "u":
                        System.Console.WriteLine("Update Email:");
                        user = dal.UpdateUser(new UserDTO { Email = System.Console.ReadLine() });
                        System.Console.WriteLine("You add the: Id - " + user.Id + " Email - " + user.Email);
                        System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;
                    case "d":
                        System.Console.WriteLine("Choose Id:");
                        dal.DeleteUser(System.Convert.ToInt32(System.Console.ReadLine()));
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