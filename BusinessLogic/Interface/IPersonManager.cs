using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BusinessLogic.Interface
{
    interface IPersonManager
    {
       PersonDTO AddNode(PersonDTO node);
        List<PersonDTO> GetListOfNodes();
        PersonDTO UpdateNode(PersonDTO node);
        void DeleteNode(int custId, int itemId);
    }
}
