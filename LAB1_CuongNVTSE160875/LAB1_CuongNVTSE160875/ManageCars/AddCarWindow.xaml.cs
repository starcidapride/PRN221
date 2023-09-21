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
    public partial class AddCarWindow : Window
    {
        public AddCarWindow()
        {
            InitializeComponent();
            SetResourceReference(StyleProperty, typeof(Window));

            Instantiate();
        }

        private void Instantiate()
        {
            SupplierId.ItemsSource = AdministratorBussiness.GetSupplierIds();
            ManufacturerId.ItemsSource = AdministratorBussiness.GetManufacturerIds();

            SupplierId.SelectedIndex = 0;
            ManufacturerId.SelectedIndex = 0;

        }
        private void OnAdd(object sender, RoutedEventArgs e)
        {
            var car = new CarInformation()
            {
                CarName = Name.Text,
                CarDescription = Description.Text,
                CarRentingPricePerDay = decimal.Parse(Price.Text),
                CarStatus = (byte)(Status.IsChecked!.Value ? 1 : 0),
                FuelType = FuelType.Text,
                NumberOfDoors = int.Parse(NumberOfDoors.Text),
                ManufacturerId = ManufacturerId.SelectedIndex + 1,
                SupplierId = SupplierId.SelectedIndex + 1,
                SeatingCapacity = int.Parse(SeatingCapacity.Text),
                Year = int.Parse(Year.Text),
            };

            var errors = AdministratorBussiness.AdministratorAddCar(car);

            string message;
            if (errors != null)
            {
                message = "Validation has identified some error(s), and they are provided below: \n"
                              + (errors.CarNameError != null ? $" + {errors.CarNameError}\n" : "")
                              + (errors.CarDescriptionError != null ? $"+ {errors.CarDescriptionError}\n" : "")
                              + (errors.NumberOfDoorsError != null ? $"+ {errors.NumberOfDoorsError}\n" : "")
                              + (errors.YearError != null ? $"+ {errors.YearError}\n" : "")
                              + (errors.FuelTypeError != null ? $"+ {errors.FuelTypeError}\n" : "")
                              + (errors.SeatingCapacityError != null ? $"+ {errors.SeatingCapacityError}\n" : "")
                              + (errors.SeatingCapacityError != null ? $"+ {errors.SeatingCapacityError}\n" : "")
                              + (errors.CarRentingPricePerDayError != null ? $"+ {errors.CarRentingPricePerDayError}\n" : "");
            } else
            {
                message = "Added Successfully";
                DialogResult = true;
                Close();
            }

            MessageBox.Show(message);

        }
    }
}
