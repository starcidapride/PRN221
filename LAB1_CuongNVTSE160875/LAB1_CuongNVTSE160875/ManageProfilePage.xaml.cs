using BussinessObjects;
using DataAccessObjects.Models;
using LAB1_CuongNVTSE160875;
using Newtonsoft.Json;
using Repositories.CustomerRepository;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFView
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class ManageProfilePage : Page
    {
        private Customer _customer;
        public ManageProfilePage(Customer customer)
        {
            InitializeComponent();
            SetResourceReference(StyleProperty, typeof(Page));

            _customer = customer;

            RenderProps(customer);
        }

        private void RenderProps(Customer customer)
        {
            Id.Text = customer.CustomerId.ToString();
            Name.Text = customer.CustomerName;
            Telephone.Text = customer.Telephone;
            Email.Text = customer.Email;
            Birthday.SelectedDate = customer.CustomerBirthday;
            Status.IsChecked = customer.CustomerStatus == 1 ? true : false;
        }

        private Customer GetCurrentProps() => new()
        {
            CustomerId = _customer.CustomerId,
            CustomerName = Name.Text,
            Telephone = Telephone.Text,
            Email = Email.Text,
            CustomerBirthday = Birthday.SelectedDate,
            CustomerStatus = (byte)(Status.IsChecked ?? true ? 1 : 0),
            Password = _customer.Password
        };

        private void RefreshProps()
        {
            var customer = CustomerBussiness.GetCustomer(_customer.CustomerId);
            if (customer == null) return;
            RenderProps(customer);
        }

        private void OnEdit(object sender, RoutedEventArgs e)
        {
            var currentCustomer = GetCurrentProps();

            var errors = CustomerBussiness.SelfUpdateCustomer(currentCustomer);

            string message;

            if (errors == null) {
                message = "Update successfully";
            } else
            {
                message = "Validation has identified some error(s), and they are provided below: \n"
                                + (errors.CustomerNameError != null ? $" + {errors.CustomerNameError}\n" : "")
                                + (errors.TelephoneError != null ? $"+ {errors.TelephoneError}\n" : "")
                                + (errors.EmailError != null ? $"+ {errors.EmailError}\n" : "")
                                + (errors.CustomerBirthdayError != null ? $"+ {errors.CustomerBirthdayError}\n" : "")
                                ;
            }

            MessageBox.Show(message);
          
            RefreshProps();
        }

        private void OnViewTransactions(object sender, RoutedEventArgs e)
        {
            var viewTransactionsPage = new ViewTransactionsPage(_customer);
            NavigationService.Navigate(viewTransactionsPage);
        }

        private void OnSignOut(object sender, RoutedEventArgs e)
        {
            var authenticationWindow = new AuthenticationWindow();
            var window = Window.GetWindow(this);
            authenticationWindow.Show();
            window.Close();
        }
    }
}
