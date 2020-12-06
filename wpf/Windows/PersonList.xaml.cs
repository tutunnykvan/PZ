using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf.ViewModels;
using DTO;
using Unity;
using Unity.Resolution;

namespace Wpf.Windows
{
    /// <summary>
    /// Interaction logic for PersonList.xaml
    /// </summary>
       public partial class PersonList : Window
    {
        PersonListViewModel _PersonListViewModel;
        CollectionViewSource _movieCollection;

        public PersonList(PersonListViewModel vm)
        {
            _PersonListViewModel = vm;
            DataContext = vm;
            InitializeComponent();

            _movieCollection = (CollectionViewSource)(Resources["PersonCollection"]);
            _movieCollection.Filter += _personCollection_Filter;
        }

        private void _personCollection_Filter(object sender, FilterEventArgs e)
        {
            var filter = txtFilter.Text;
            var person = e.Item as PersonDTO;
            if (person.FirstName.Contains(filter) || person.LastName.Contains(filter) || person.Birthday.ToString().Contains(filter) || person.RoleId.ToString().Contains(filter))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            _movieCollection.View.Refresh();
        }

        private void btnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            var personEditWindow = ((App)Application.Current).Container.Resolve<PersonEdit>();
            personEditWindow.ShowDialog();
            _PersonListViewModel.Update();
        }

        private void dgPerson_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            var item = (PersonDTO)grid.SelectedItem;
            var detailsViewModel = ((App)Application.Current).Container.Resolve<PersonEditViewModel>(new ParameterOverride("person", item));
            var movieDetailsWindow = new PersonEdit(detailsViewModel);
            movieDetailsWindow.ShowDialog();
            _PersonListViewModel.Update();
        }
    }
}
