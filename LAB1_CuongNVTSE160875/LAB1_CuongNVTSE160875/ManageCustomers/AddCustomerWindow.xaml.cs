using BussinessObjects;
using DataAccessObjects.Models;
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

namespace WPFView
{
    /// <summary>
    /// Interaction logic for AddUpdateCarWindow.xaml
    /// </summary>
    public partial class AddCustomerWindow : Window
    {
        public AddCustomerWindow()
        {
            InitializeComponent();
            SetResourceReference(StyleProperty, typeof(Window));
        }

        private void OnAdd(object sender, RoutedEventArgs e)
        {
            var customer = new Customer()
            {
                CustomerName = Name.Text,
                Telephone = Telephone.Text,
                Email = Email.Text,
                CustomerBirthday = Birthday.SelectedDate,
                CustomerStatus = (byte)(Status.IsChecked!.Value ? 1 : 0),
                Password = Password.Text
            };

            var errors = AdministratorBussiness.AdministratorAddCustomer(customer);

            string message;
            if (errors != null)
            {
                message = "Validation has identified some error(s), and they are provided below: \n"
                              + (errors.CustomerNameError != null ? $" + {errors.CustomerNameError}\n" : "")
                              + (errors.TelephoneError != null ? $"+ {errors.TelephoneError}\n" : "")
                              + (errors.EmailError != null ? $"+ {errors.EmailError}\n" : "")
                              + (errors.CustomerBirthdayError != null ? $"+ {errors.CustomerBirthdayError}\n" : "")
                              ;
            }
            else
            {
                message = "Added successfully.";

                DialogResult = true;
                var parentWindow = GetWindow(this);
                parentWindow.Close();
            }

            MessageBox.Show(message);
        }
    }
}
