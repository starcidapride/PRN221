using DataAccessObjects.Models;
using Repositories.CustomerRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Utilities.Validations;

namespace BussinessObjects;

    public class CustomerBussiness
    {
        public static CustomerErrors? SelfUpdateCustomer(Customer _customer)
        {
            var errors = new CustomerErrors()
            {   
              
                CustomerNameError = CustomerValidation.ValidateCustomerName(_customer.CustomerName),
                CustomerBirthdayError = CustomerValidation.ValidateCustomerBirthday(_customer.CustomerBirthday),
                EmailError = CustomerValidation.ValidateEmail(_customer.Email),
                TelephoneError = CustomerValidation.ValidateTelephone(_customer.Telephone)
            };

            if (!errors.NoError()) return errors;

            CustomerRepository.Update(_customer);

            return null;
        }

        public static Customer? GetCustomer(int id) => CustomerRepository.Get(id);

        public static List<RentingDetail>? GetRentingDetails(int id) => RentingDetailsRepository.GetRentingDetails(id);

        public static List<RentingTransaction>? GetRentingTransactions(int customerId)
        => RentingTransactionRepository.GetMany(customerId);
}
