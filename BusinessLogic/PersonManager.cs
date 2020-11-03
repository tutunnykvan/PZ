using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interface;
using DAL.Interface;
using DTO;

namespace BusinessLogic.Concrete
{
    class PersonManager
    {
        private readonly IPersonDAL _personManager;

        public PersonManager(IPersonDAL PersonDAL) { _personManager = PersonDAL; }
        public PersonDTO AddPerson(PersonDTO person)
        {
            return _personManager.CreatePerson(person);
        }

        public void DeletePerson(int id)
        {
            _personManager.DeletePerson(id);
        }

        public List<PersonDTO> GetListOfPerson()
        {
            return _personManager.GetAllPerson();
        }

        public PersonDTO UpdatePerson(PersonDTO person)
        {
            return _personManager.UpdatePerson(person);
        }
    }
}
