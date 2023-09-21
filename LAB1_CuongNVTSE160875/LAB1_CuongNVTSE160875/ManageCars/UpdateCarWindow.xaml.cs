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
    public partial class UpdateCarWindow : Window
    {
        private CarInformation _car;
        public UpdateCarWindow(CarInformation car)
        {
            InitializeComponent();
            SetResourceReference(StyleProperty, typeof(Window));

            _car = car;

            Instantiate();
            Render();
        }

        private void Instantiate()
        {
            SupplierId.ItemsSource = AdministratorBussiness.GetSupplierIds();
            ManufacturerId.ItemsSource = AdministratorBussiness.GetManufacturerIds();

            SupplierId.SelectedIndex = 0;
            ManufacturerId.SelectedIndex = 0;
        }

        private void Render()
        {
            Name.Text = _car.CarName;
            Description.Text = _car.CarDescription;
            Price.Text =  _car.CarRentingPricePerDay!.Value.ToString();
            ManufacturerId.Text = _car.ManufacturerId.ToString();
            SupplierId.Text = _car.SupplierId.ToString();
            Id.Text = _car.CarId.ToString();
            NumberOfDoors.Text = _car.NumberOfDoors.ToString();
            FuelType.Text = _car?.FuelType?.ToString();
            Year.Text = _car?.Year.ToString();
            Status.IsChecked = _car!.CarStatus == 1;
            SeatingCapacity.Text = _car?.SeatingCapacity.ToString();
        }

        private void OnUpdate(object sender, RoutedEventArgs e)
        {
            var car = new CarInformation()
            {
                CarId = _car.CarId,
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

            var errors = AdministratorBussiness.AdministratorUpdateCar(car);

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
                              + (errors.CarRentingPricePerDayError != null ? $"+ {errors.CarRentingPricePerDayError}\n" : "");
                
                _car = AdministratorBussiness.GetCarById(_car.CarId)!;
                Render();
            } else
            {
                message = "Updated Successfully";
                DialogResult = true;
                Close();
            }

            MessageBox.Show(message);

        }
    }
}
