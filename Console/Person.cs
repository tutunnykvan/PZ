using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL.Concrete;
using System.Configuration;


namespace Console
{
    class Person
    {
        PersonDAL dal = new PersonDAL(ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString);
        PersonDTO person;
        public void PersonDALMenu()
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
                        System.Console.WriteLine("Input Person :");
                        person = dal.CreatePerson(new PersonDTO { FirstName = System.Console.ReadLine() });
                        System.Console.WriteLine("You add the: Id - " + person.PersonId + " Name - " + person.FirstName);
                        System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;
                    case "r":
                        System.Console.Write("Choose Id: ");
                        person = dal.GetPersonById(System.Convert.ToInt32(System.Console.ReadLine()));
                        System.Console.WriteLine("You read the: Id - " + person.PersonId + " Name - " + person.FirstName);
                        System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;
                    case "rall":
                        List<PersonDTO> categories = dal.GetAllPerson();
                        for (int i = 0; i < person.Count; i++)
                        {
                            System.Console.WriteLine("Id - " + person[i].RoleId + " Name - " + person[i].FirstName);
                        }
                        System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;
                    case "u":
                        System.Console.WriteLine("Update Name:");
                        person = dal.UpdatePerson(new PersonDTO { FirstName = System.Console.ReadLine() });
                        System.Console.WriteLine("You add the: Id - " + person.PersonId + " Name - " + person.FirstName);
                        System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;
                    case "d":
                        System.Console.WriteLine("Choose Id:");
                        dal.DeletePerson(System.Convert.ToInt32(System.Console.ReadLine()));
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

