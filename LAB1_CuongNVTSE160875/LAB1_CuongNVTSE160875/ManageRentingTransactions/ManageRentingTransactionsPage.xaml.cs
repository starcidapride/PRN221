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
    public partial class ManageRentingTransactionsPage : Page
    {
        public ManageRentingTransactionsPage()
        {
            InitializeComponent();

            RenderRentingTransactionList();
        }

        private void RenderRentingTransactionList()
        {
            DataGrid.ItemsSource = AdministratorBussiness.RenderRentingTransactionList();
        }

        private void OnDelete(object sender, RoutedEventArgs e)
        {
            var rentingTransaction = (RentingTransaction) DataGrid.SelectedItem;

            if (rentingTransaction == null) return;

            AdministratorBussiness.AdministratorDeleteRentingTransaction(rentingTransaction);

            RenderRentingTransactionList();
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
