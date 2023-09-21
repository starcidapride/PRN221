using BussinessObjects;
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
    public partial class NavigatorPage : Page
    {
        public NavigatorPage()
        {
            InitializeComponent();
        }

        private void OnManageCustomers(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManageCustomersPage());
        }

        private void OnManageCars(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManageCarsPage());
        }

        private void OnManageRentingTransactions(object sender, RoutedEventArgs e)
        {
            {
                NavigationService.Navigate(new ManageRentingTransactionsPage());
            }
        }

            private void OnGenerateStatistic(object sender, RoutedEventArgs e)
            {
                try
                {
                    AdministratorBussiness.GenerateReport(
        StartDate.SelectedDate!.Value,
        EndDate.SelectedDate!.Value
        );
                MessageBox.Show("Statistic generated successfully.");
            }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occurred {ex.Message}.");
                }
                
            }
        }
    }
