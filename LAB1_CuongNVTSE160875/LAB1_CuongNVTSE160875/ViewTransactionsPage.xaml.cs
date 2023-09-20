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
            RenderNavigation();
        }

        public void RenderNavigation()
        {
            var maxPages = CustomerBussiness.GetRentingTransactionPages(_customer.CustomerId);
            Page.Text = $"{_currentPage}/{maxPages}";
            NextButton.IsEnabled = !(_currentPage == maxPages);
            PreviousButton.IsEnabled = !(_currentPage == 1);
        }

        private void OnNext(object sender, EventArgs e)
        {
            _currentPage++;
            RenderCustomerList();
            RenderNavigation();
        }

        private void OnPrevious(object sender, EventArgs e)
        {
            _currentPage--;
            RenderCustomerList();
            RenderNavigation();
        }

        public void RenderCustomerList()
        {
            var rentingTransactionList = CustomerBussiness.GetRentingTransactions(_customer.CustomerId, _currentPage);

            foreach (var transaction in rentingTransactionList)
            {
                var row = new TableRow();

                var cell1 = new TableCell();
                cell1.BorderBrush = Brushes.Black;
                cell1.BorderThickness = new Thickness(1, 0, 1, 1);
                cell1.Blocks.Add(new Paragraph(new Run(transaction.RentingTransationId.ToString()))
                {
                    Margin = Margin = new Thickness(5)
                });
                cell1.TextAlignment = TextAlignment.Center;

                var cell2 = new TableCell();
                cell2.BorderBrush = Brushes.Black;
                cell2.BorderThickness = new Thickness(0, 0, 1, 1);
                var dateOnly = transaction.RentingDate.HasValue ? transaction.RentingDate : null;
                cell2.Blocks.Add(new Paragraph(new Run(DateOnly.FromDateTime(dateOnly!.Value).ToString()))
                {
                    Margin = Margin = new Thickness(5)
                });
                cell2.TextAlignment = TextAlignment.Center;

                var cell3 = new TableCell();
                cell3.BorderBrush = Brushes.Black;
                cell3.BorderThickness = new Thickness(0, 0, 1, 1);
                cell3.Blocks.Add(new Paragraph(new Run(transaction.TotalPrice.ToString()))
                {
                    Margin = Margin = new Thickness(5)
                });
                cell3.TextAlignment = TextAlignment.Center;

                var cell4 = new TableCell();
                cell4.BorderBrush = Brushes.Black;
                cell4.BorderThickness = new Thickness(0, 0, 1, 1);
                cell4.Blocks.Add(new Paragraph(new Run(transaction.RentingStatus == 1 ? "Yes" : "No"))
                {
                    Margin = Margin = new Thickness(5)
                });
                cell4.TextAlignment = TextAlignment.Center;

                var cell5 = new TableCell();
                cell5.BorderBrush = Brushes.Black;
                cell5.BorderThickness = new Thickness(0, 0, 1, 1);
                var button = new Button()
                {
                    Content = "Details",
                    Margin = Margin = new Thickness(5)
                };

                button.Click += (object sender, RoutedEventArgs e) =>
                {
                    var detailsPage = new TransactionDetails(transaction.RentingTransationId);
                    detailsPage.Show();
                };
                cell5.Blocks.Add(new BlockUIContainer(button));
                cell5.TextAlignment = TextAlignment.Center;

                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);
                row.Cells.Add(cell5);

                TransactionList.Rows.Add(row);
            }
        }

    }
}
