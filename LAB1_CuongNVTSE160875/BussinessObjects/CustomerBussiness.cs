using DataAccessObjects.Models;
using Repositories.CustomerRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BussinessObjects
{
    public class CustomerBussiness
    {
        public static UpdateCustomerErrors? SelfUpdateCustomer(Customer _customer)
        {
            var errors = new UpdateCustomerErrors()
            {   
                CustomerIdError = ValidateCustomerId(_customer.CustomerId),
                CustomerNameError = ValidateCustomerName(_customer.CustomerName),
                CustomerBirthdayError = ValidateCustomerBirthday(_customer.CustomerBirthday),
                EmailError = ValidateEmail(_customer.Email),
                TelephoneError = ValidateTelephone(_customer.Telephone)
            };

            if (!errors.NoError()) return errors;

            CustomerRepository.Update(_customer);

            return null;
        }

        private static string? ValidateCustomerId(int customerId)
        {
                bool customerExists = RentingTransactionRepository.Get(customerId) != null;

                if (!customerExists)
                {
                    return "Customer with the provided Id does not exist.";
                }

                return null;
        }

        private static string? ValidateCustomerName(string? customerName)
        {
            if (customerName == null) return null;

            if (!Regex.IsMatch(customerName, "^[A-Za-z0-9 ]{2,50}$"))
            {
                return "Customer name must be between 2 and 50 characters and contain only letters and numbers.";
            }
            return null;
        }

        private static string? ValidateTelephone(string? telephone)
        {
            if (telephone == null) return null;

            if (!Regex.IsMatch(telephone, "^\\d{9,12}$"))
            {
                return "Telephone number must be between 9 and 12 digits.";
            }
            return null;
        }

        private static string? ValidateEmail(string? email)
        {
            if (email == null) return null;

            if (!Regex.IsMatch(email, "^(?=.{1,50}$)[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$"))
            {
                return "Invalid email format. Email must be valid and have a maximum length of 50 characters.";
            }
            return null;
        }

        private static string? ValidateCustomerBirthday(DateTime? customerBirthday)
        {
            if (customerBirthday == null) return null;

            if (customerBirthday > DateTime.Now)
            {
                return "Customer birthday cannot be in the future.";
            }
            return null;
        }

        public static Customer? GetCustomer(int id) => CustomerRepository.Get(id);

        public static List<RentingDetail>? GetRentingDetails(int id) => RentingTransactionRepository.GetRentingDetails(id);

        public static List<RentingTransaction> GetRentingTransactions(int customerId, int pageNumber) =>
            RentingTransactionRepository.GetMany(customerId, pageNumber, 10);

        public static int GetRentingTransactionPages(int customerId) =>
           RentingTransactionRepository.GetPages(customerId, 10);
    }


    public class UpdateCustomerErrors
    {
        public string? CustomerIdError { get; set; }
        public string? CustomerNameError { get; set; }
        public string? TelephoneError { get; set;}
        public string? EmailError { get; set; }
        public string? CustomerBirthdayError { get; set; }
        public string? PasswordError { get; set; }

        public bool NoError()
        {
            return CustomerNameError == null &&
                TelephoneError == null &&
                EmailError == null &&
                EmailError == null &&
                CustomerBirthdayError == null
                ;
        }
    }
}
