using DataAccessObjects.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects.DAOs;
public class CustomerDAO
{
    private static CustomerDAO? _instance;
    private FucarRentingManagementContext _context;

    private static readonly object _lock = new object();

    public CustomerDAO()
        {
            _context = new FucarRentingManagementContext();
        }
    public static CustomerDAO Instance
    {
        get
        {
                lock (_lock)
                {
                    if (_instance == null)
                        {
                            _instance = new CustomerDAO();
                        }
                }
            return _instance;
        }
    }

    public Customer? GetCustomer(int customerId) =>
        _context.Customers
        .FirstOrDefault(customer => customer.CustomerId == customerId);

    public Customer? GetCustomerByEmailAndPassword(string email, string password)
    {
        return _context.Customers
            .FirstOrDefault(customer => customer.Email == email 
            && customer.Password == password);
    }

    public bool UpdateCustomer(Customer customer)
    {
        try
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return true;

        } catch (Exception ex)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt"), true))
            {
                outputFile.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
