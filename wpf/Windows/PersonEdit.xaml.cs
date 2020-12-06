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


namespace Wpf.Windows
{
    /// <summary>
    /// Interaction logic for PersonEdit.xaml
    /// </summary>
    
    
        public partial class PersonEdit : Window
        {
            PersonEditViewModel _PersonEditViewModel;
            public PersonEdit(PersonEditViewModel vm)
            {
                _PersonEditViewModel = vm;
                DataContext = vm;

                InitializeComponent();
            }

            private void btnSave_Click(object sender, RoutedEventArgs e)
            {
                _PersonEditViewModel.Save();
                DialogResult = true;
                this.Close();
            }
        }
    
}
