using BussinessObjects;
using DataAccessObjects.DAOs;
using DataAccessObjects.Models;
using Repositories.CarRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
    public partial class ManageCustomersPage : Page
    {
        public ManageCustomersPage()
        {
            InitializeComponent();

            RenderCustomerList();
        }

        private void RenderCustomerList(string? searchValue = null)
        {
            if (searchValue == null)
            {
                DataGrid.ItemsSource = AdministratorBussiness.GetCustomers();
            } else
            {
                DataGrid.ItemsSource = AdministratorBussiness.GetCustomers(searchValue);
            }
        }

        private void OnAdd(object sender, RoutedEventArgs e)
        {
            var addCustomerWindow = new AddCustomerWindow();
            var dialog = addCustomerWindow.ShowDialog();
            if (dialog == true)
            {
                RenderCustomerList();
            }
        }

        private void OnUpdate(object sender, RoutedEventArgs e)
        {
            var customer = (Customer) DataGrid.SelectedItem;

            if (customer == null) return;

            var updateCustomerWindow = new UpdateCustomerWindow(customer);
            var dialog = updateCustomerWindow.ShowDialog();
            if (dialog == true)
            {
                RenderCustomerList();
            }
        }

        private void OnDelete(object sender, RoutedEventArgs e)
        {
            var customer = (Customer)DataGrid.SelectedItem;

            if (customer == null) return;

            AdministratorBussiness.AdministratorDeleteCustomer(customer);

            RenderCustomerList();
        }

        private void OnSearch(object sender, RoutedEventArgs e)
        {
            var searchValue = SearchValue.Text;

            RenderCustomerList(searchValue);
        }
    }
    }
