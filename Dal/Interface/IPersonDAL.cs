using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
   public interface IPersonDAL
    {

        PersonDTO GetPersonById(int id);
        List<PersonDTO> GetAllPerson();
        PersonDTO UpdatePerson(PersonDTO person);
       PersonDTO CreatePerson(PersonDTO person);
        void DeletePerson(int id);


    }
}
