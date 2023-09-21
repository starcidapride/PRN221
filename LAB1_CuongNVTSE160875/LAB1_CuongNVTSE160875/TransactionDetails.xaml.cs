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
using System.Windows.Shapes;

namespace WPFView
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TransactionDetails : Window
    {
        private int _id;
        public TransactionDetails(int id)
        {
            InitializeComponent();

            _id = id;

            RenderTransactionDetails();

        }

        private void RenderTransactionDetails()
        {
            var rentingDetailsList = CustomerBussiness.GetRentingDetails(_id);

            DataGrid.ItemsSource = rentingDetailsList;
            }
        }
}
