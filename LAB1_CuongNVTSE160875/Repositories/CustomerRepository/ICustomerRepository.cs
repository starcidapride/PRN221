using DataAccessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.CustomerRepository;
public interface ICustomerRepository : IRepository<Customer>
{
    public static abstract Customer? GetCustomerByEmailAndPassword(string email, string password);

}