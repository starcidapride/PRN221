using BussinessObjects;
using DataAccessObjects.Models;
using Repositories.CustomerRepository;
using System;
using System.Collections;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class ViewTransactionsPage : Page
    {
        private Customer _customer;
        private int _currentPage = 1;
        public ViewTransactionsPage(Customer customer)
        {
            InitializeComponent();

            _customer = customer;

            RenderCustomerList();
        }

        public void RenderCustomerList()
        {
            var rentingTransactionList = CustomerBussiness.GetRentingTransactions(_customer.CustomerId);
            DataGrid.ItemsSource = rentingTransactionList;
        }

        private void OnDetails(object sender, EventArgs e)
        {
            var rentingTransaction = (RentingTransaction)DataGrid.SelectedItem;

            if (rentingTransaction == null) return;

            var detailsWindow = new TransactionDetails(rentingTransaction.RentingTransationId);

            detailsWindow.Show();
        }

    }
}
