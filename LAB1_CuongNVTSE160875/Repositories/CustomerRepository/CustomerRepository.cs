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
    public static bool Add(Customer entity) => CustomerDAO.Instance.AddCustomer(entity);

    public static Customer? Get(int id) => CustomerDAO.Instance.GetCustomer(id);

    public static Customer? GetCustomerByEmailAndPassword(string email, string password) 
        => CustomerDAO.Instance.GetCustomerByEmailAndPassword(email, password);

    public static bool Update(Customer entity) => CustomerDAO.Instance.UpdateCustomer(entity);

    public static List<Customer> GetAll() => CustomerDAO.Instance.GetCustomers();

    public static List<Customer> GetMany(string searchValue) => CustomerDAO.Instance.GetCustomers(searchValue);


    public static bool Delete(Customer id) => CustomerDAO.Instance.DeleteCustomer(id);
}