using Bll.interfaces;
using DTO;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Wpf.ViewModels
{
   
    public class PersonListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        private IPersonManager _manager;
        private ObservableCollection<PersonDTO> _personList;
        public ObservableCollection<PersonDTO> PersonList
        {
            get { return _personList; }
            set
            {
                _personList = value;
                OnPropertyChanged(nameof(PersonList));
            }
        }

        public PersonListViewModel(IPersonManager manager)
        {
            _manager = manager;
            Update();
        }

        public void Update()
        {
            var persons = _manager.GetListOfPerson();
            PersonList = new ObservableCollection<PersonDTO>(persons);
        }
    }
}
