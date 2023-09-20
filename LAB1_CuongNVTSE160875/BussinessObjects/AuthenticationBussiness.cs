using DataAccessObjects.Models;
using Repositories.CustomerRepository;
using System.Data;
using Utilities;

namespace BussinessObjects
{
    public class AuthenticationBussiness
    {
        public static SignInResult ProcessSignIn(string email, string password)
        {
            if (ConfigurationUtilites.CheckAdministrator(email, password))
            {
                return new SignInResult()
                {
                    Role = AccountRole.Administrator,
                    Details = null
                };
            }

            var customer = CustomerRepository.GetCustomerByEmailAndPassword(email, password);

            if (customer == null)
            {
                return new SignInResult()
                {
                    Role = AccountRole.None,
                    Details = null
                };
            } 

            return new SignInResult()
                {
                    Role = AccountRole.Customer,
                    Details = customer
                };
        }
    }

    public class SignInResult
    {
        public AccountRole Role { get; set; }
        public Customer? Details { get; set; }
    }

    public enum AccountRole
    {   
        None,
        Customer,
        Administrator
    }
}