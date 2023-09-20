using DataAccessObjects.DAOs;
using DataAccessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.CustomerRepository;

public class CustomerRepository : ICustomerRepository
{
    public static bool Add(Customer entity)
    {
        throw new NotImplementedException();
    }

    public static Customer? Get(int id) => CustomerDAO.Instance.GetCustomer(id);

    public static List<Customer> GetMany(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public static Customer? GetCustomerByEmailAndPassword(string email, string password) 
        => CustomerDAO.Instance.GetCustomerByEmailAndPassword(email, password);

    public static bool Update(Customer entity) => CustomerDAO.Instance.UpdateCustomer(entity);

    public static int GetPages(int pageSize)
    {
        throw new NotImplementedException();
    }
}