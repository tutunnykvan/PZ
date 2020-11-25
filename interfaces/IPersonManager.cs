using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Bll.interfaces
{
   public interface IPersonManager
    {
        PersonDTO AddPerson(PersonDTO peroson);
        List<PersonDTO> GetListOfPerson();
        PersonDTO UpdatePerson(PersonDTO node);
        void DeletePerson(int Id);
    }
}