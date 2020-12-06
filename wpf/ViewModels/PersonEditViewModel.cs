using Bll.interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.ViewModels
{
    public class PersonEditViewModel : INotifyPropertyChanged
    {
        private IPersonManager _manager;

        private PersonDTO _person;
        public PersonDTO Person
        {
            get { return _person; }
            set
            {
                _person = value;
                OnPropertyChanged(nameof(Person));
            }
        }

        public List<RoleDTO> Role { get; set; }
       

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public PersonEditViewModel(IPersonManager manager, PersonDTO person)
        {
            _manager = manager;
           Person = person ?? new PersonDTO();
           Role = _manager.GetListOfRole();
                  
        }

        public void Save()
        {
           Person = _manager.UpdatePerson(Person);
        }
    }
}
