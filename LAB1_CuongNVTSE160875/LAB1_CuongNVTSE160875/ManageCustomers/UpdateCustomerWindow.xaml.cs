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
    public partial class UpdateCustomerWindow : Window
    {
        private Customer _customer;
        public UpdateCustomerWindow(Customer customer)
        {
            InitializeComponent();
            SetResourceReference(StyleProperty, typeof(Window));

            _customer = customer;

            Render();
        }

        private void Render()
        {
            Name.Text =  _customer!.CustomerName;
            Telephone.Text = _customer!.Telephone;
            Email.Text =  _customer!.Email;
            Birthday.SelectedDate = _customer!.CustomerBirthday;
            Status.IsChecked = _customer!.CustomerStatus == 1;
            Password.Text = _customer!.Password;
        }

        private void OnUpdate(object sender, RoutedEventArgs e)
        {
            var customer = new Customer()
            {   
                CustomerId = _customer!.CustomerId,
                CustomerName = Name.Text,
                Telephone = Telephone.Text,
                Email = Email.Text,
                CustomerBirthday = Birthday.SelectedDate,
                CustomerStatus = (byte)(Status.IsChecked!.Value ? 1 : 0),
                Password = Password.Text
            };

            var errors = AdministratorBussiness.AdministratorUpdateCustomer(customer);

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
                message = "Updated successfully.";

                DialogResult = true;
                var parentWindow = GetWindow(this);
                parentWindow.Close();
            }

            MessageBox.Show(message);

        }
    }
}
