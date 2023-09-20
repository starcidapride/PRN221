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

            foreach (var details in rentingDetailsList!)
            {
                var row = new TableRow();

                var cell1 = new TableCell();
                cell1.BorderBrush = Brushes.Black;
                cell1.BorderThickness = new Thickness(1, 0, 1, 1);
                cell1.Blocks.Add(new Paragraph(new Run(details.CarId.ToString())));
                cell1.TextAlignment = TextAlignment.Center;

                var cell2 = new TableCell();
                cell2.BorderBrush = Brushes.Black;
                cell2.BorderThickness = new Thickness(0, 0, 1, 1);
                cell2.Blocks.Add(new Paragraph(new Run(DateOnly.FromDateTime(details.StartDate).ToString())));
                cell2.TextAlignment = TextAlignment.Center;

                var cell3 = new TableCell();
                cell3.BorderBrush = Brushes.Black;
                cell3.BorderThickness = new Thickness(0, 0, 1, 1);
                cell3.Blocks.Add(new Paragraph(new Run(DateOnly.FromDateTime(details.EndDate).ToString())));
                cell3.TextAlignment = TextAlignment.Center;

                var cell4 = new TableCell();
                cell4.BorderBrush = Brushes.Black;
                cell4.BorderThickness = new Thickness(0, 0, 1, 1);
                cell4.Blocks.Add(new Paragraph(new Run(details.Price.ToString())));
                cell4.TextAlignment = TextAlignment.Center;

                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);

                DetailsList.Rows.Add(row);
            }
        }
    }
}
