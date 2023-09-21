using DataAccessObjects.Models;
using OfficeOpenXml;
using Repositories.CarRepository;
using Repositories.CustomerRepository;
using Repositories.ManufacturerRepository;
using Repositories.SupplierRepository;
using Utilities.Validations;

namespace BussinessObjects;
public class AdministratorBussiness
{
    public static List<RentingTransaction> RenderRentingTransactionList() =>
        RentingTransactionRepository.GetAll();

    public static List<Customer> GetCustomers() =>
        CustomerRepository.GetAll();
    public static List<Customer> GetCustomers(string searchValue) =>
        CustomerRepository.GetMany(searchValue);

    public static List<CarInformation> GetCars() =>
        CarRepository.GetAll();

    public static List<CarInformation> GetCars(string searchValue) =>
        CarRepository.GetMany(searchValue);

    public static void AdministratorDeleteRentingTransaction(RentingTransaction transaction)
        => RentingTransactionRepository.Delete(transaction);
    public static CustomerErrors? AdministratorUpdateCustomer(Customer _customer)
    {
        var errors = new CustomerErrors()
        {
            CustomerNameError = CustomerValidation.ValidateCustomerName(_customer.CustomerName),
            CustomerBirthdayError = CustomerValidation.ValidateCustomerBirthday(_customer.CustomerBirthday),
            EmailError = CustomerValidation.ValidateEmail(_customer.Email),
            TelephoneError = CustomerValidation.ValidateTelephone(_customer.Telephone),
            PasswordError = CustomerValidation.ValidatePassword(_customer.Password),
        };

        if (!errors.NoError()) return errors;

        CustomerRepository.Update(_customer);

        return null;
    }

    public static CustomerErrors? AdministratorAddCustomer(Customer _customer)
    {
        var errors = new CustomerErrors()
        {
            CustomerNameError = CustomerValidation.ValidateCustomerName(_customer.CustomerName),
            CustomerBirthdayError = CustomerValidation.ValidateCustomerBirthday(_customer.CustomerBirthday),
            EmailError = CustomerValidation.ValidateEmail(_customer.Email),
            TelephoneError = CustomerValidation.ValidateTelephone(_customer.Telephone),
            PasswordError = CustomerValidation.ValidatePassword(_customer.Password),
        };

        if (!errors.NoError()) return errors;

        CustomerRepository.Add(_customer);

        return null;
    }

   
    public static CarErrors? AdministratorAddCar(CarInformation _car)
    {
        var errors = new CarErrors()
        {
            CarNameError = CarValidation.ValidateCarName(_car.CarName),
            CarDescriptionError = CarValidation.ValidateCarDescription(_car.CarDescription),
            CarRentingPricePerDayError = CarValidation.ValidateCarRentingPricePerDay(_car.CarRentingPricePerDay),
            FuelTypeError = CarValidation.ValidateFuelType(_car.FuelType),
            NumberOfDoorsError = CarValidation.ValidateNumberOfDoors(_car.NumberOfDoors),
            SeatingCapacityError = CarValidation.ValidateSeatCapacity(_car.SeatingCapacity),
            YearError = CarValidation.ValidateYear(_car.Year)
        };

        if (!errors.NoError()) return errors;

        CarRepository.Add(_car);
        return null;
    }

    public static CarErrors? AdministratorUpdateCar(CarInformation _car)
    {
        var errors = new CarErrors()
        {
            CarNameError = CarValidation.ValidateCarName(_car.CarName),
            CarDescriptionError = CarValidation.ValidateCarDescription(_car.CarDescription),
            CarRentingPricePerDayError = CarValidation.ValidateCarRentingPricePerDay(_car.CarRentingPricePerDay),
            FuelTypeError = CarValidation.ValidateFuelType(_car.FuelType),
            NumberOfDoorsError = CarValidation.ValidateNumberOfDoors(_car.NumberOfDoors),
            SeatingCapacityError = CarValidation.ValidateSeatCapacity(_car.SeatingCapacity),
            YearError = CarValidation.ValidateYear(_car.Year)
        };

        if (!errors.NoError()) return errors;

        CarRepository.Update(_car);
        return null;
    }

    public static void AdministratorDeleteCar(CarInformation _car)
    {
        _car.CarStatus = 0;

        CarRepository.Update(_car);
    }

    public static void AdministratorDeleteCustomer(Customer _customer)
    {
        CustomerRepository.Delete(_customer);
    }

    public static CarInformation? GetCarById(int id) => CarRepository.Get(id);
    public static List<int> GetSupplierIds() => SupplierRepository.GetSupplierIds();
    public static List<int> GetManufacturerIds() => ManufacturerRepository.GetManufacturerIds();
    public static void GenerateReport(DateTime startDate, DateTime endDate)
    {
        // Set the license context for EPPlus
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        // Get the user's "Documents" folder path
        string documentsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Specify the file path where you want to save the Excel report in the "Documents" folder
        string filePath = Path.Combine(documentsFolderPath, "ExcelReport.xlsx");

        // Create a new Excel package
        using (var package = new ExcelPackage())
        {
            // Add a new worksheet to the Excel package
            var worksheet = package.Workbook.Worksheets.Add("Report");

            var startCarIds = RentingDetailsRepository.GetAll(startDate, endDate, true).Select(rd => rd.CarId);
            var endCarIds = RentingDetailsRepository.GetAll(startDate, endDate, false).Select(rd => rd.CarId);

            // Populate data in the worksheet
            worksheet.Cells["A1"].Value = "Car Ids started in between start date and end date:";
            worksheet.Cells["A2"].LoadFromCollection(startCarIds, false);

            worksheet.Cells["C1"].Value = "Car Ids ended in between start date and end date:";
            worksheet.Cells["C2"].LoadFromCollection(endCarIds, false);

            // Save the Excel package to the specified file path
            package.SaveAs(new FileInfo(filePath));

            Console.WriteLine($"Excel report generated and saved to {filePath}");
        }
    }
}

