using Azure;
using BussinessObjects;
using DataAccessObjects.Models;
using Utilities.Validations;
using System;

using System.Windows;
using System.Windows.Controls;

namespace WPFView
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddUpdateCustomerWindow : Window
    {
        private bool _isAdd;
        private Customer? _customer;
        public AddUpdateCustomerWindow(bool isAdd, Customer? customer = null)
        {
            InitializeComponent();
            _isAdd = isAdd;

            _customer = customer;
            
            RenderInit();

        }

        private void RenderInit()
        {
            if (_isAdd)
            {
                Id.Visibility = Visibility.Hidden;
            }
            else
            {
                Id.Text = _customer!.CustomerId.ToString();
            }
            Window.Title = _isAdd ? "Add Customer" : "Update Customer";
            Button.Content = _isAdd ? "Add" : "Update";

            Name.Text = !_isAdd ? _customer!.CustomerName : "";
            Telephone.Text = !_isAdd ? _customer!.Telephone : "";
            Email.Text = !_isAdd ? _customer!.Email : "";
            Birthday.SelectedDate = !_isAdd ? _customer!.CustomerBirthday : DateTime.Now;
            Status.IsChecked = !_isAdd ? _customer!.CustomerStatus == 1 : true;
            Password.Text = !_isAdd ? _customer!.Password : "";
        }


        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            
            CustomerErrors? errors;

            Customer customer;
            if (_isAdd)
            {
                customer = new Customer()
                {
                    CustomerName = Name.Text,
                    Telephone = Telephone.Text,
                    Email = Email.Text,
                    CustomerBirthday = Birthday.SelectedDate,
                    CustomerStatus = (byte)(Status.IsChecked!.Value ? 1 : 0),
                    Password = Password.Text
                };

                errors = AdministratorBussiness.AdministratorAddCustomer(customer);
            } else
            {
                customer = new Customer()
                {   
                    CustomerId = _customer!.CustomerId,
                    CustomerName = Name.Text,
                    Telephone = Telephone.Text,
                    Email = Email.Text,
                    CustomerBirthday = Birthday.SelectedDate,
                    CustomerStatus = (byte)(Status.IsChecked!.Value ? 1 : 0),
                    Password = Password.Text
                };
                errors = AdministratorBussiness.AdministratorUpdateCustomer(customer);
            }

            string message;
            if (errors != null)
            {
                message = "Validation has identified some error(s), and they are provided below: \n"
                              + (errors.CustomerNameError != null ? $" + {errors.CustomerNameError}\n" : "")
                              + (errors.TelephoneError != null ? $"+ {errors.TelephoneError}\n" : "")
                              + (errors.EmailError != null ? $"+ {errors.EmailError}\n" : "")
                              + (errors.CustomerBirthdayError != null ? $"+ {errors.CustomerBirthdayError}\n" : "")
                              ;
            } else
            {
                message = $"{(_isAdd ? "Added" : "Updated")} successfully.";

                DialogResult = true;
                var parentWindow = GetWindow(this);
                parentWindow.Close();
            }

            MessageBox.Show(message);
        }
    }
}
