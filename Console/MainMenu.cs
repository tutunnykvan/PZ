using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL.Concrete;
namespace ConsoleApp5
{
    class MainMenu
    {

        Person P = new Perosn();
        Admin A = new Admin(); 
        Role R = new Role();
        User U = new User();
        public void Start()
        {
            System.Console.WriteLine("Welcome in Console");

            while (true)
            {
                System.Console.WriteLine("Choose:");
                System.Console.WriteLine("a - admin");
                System.Console.WriteLine("p - person");
                System.Console.WriteLine("r -Role");
                System.Console.WriteLine("u - user");
                

                string d = System.Console.ReadLine();

                switch (d)
                {
                    case "a":
                        System.Console.WriteLine("you chose a");
                        AdminDTO admin = new AdminDTO();
                        A.AdminDALMenu();
                        break;
                    case "p":
                        System.Console.WriteLine("you chose p");
                        P.PersonDALMenu();
                        break;
                    case "r":
                        System.Console.WriteLine("you chose r");
                        R.RoleDALMenu();
                        break;
                    case "u":
                        System.Console.WriteLine("you chose u");
                        U.UserDALMenu();
                        break;

                    default:
                        return;
                }


            }
        }
    }



}

