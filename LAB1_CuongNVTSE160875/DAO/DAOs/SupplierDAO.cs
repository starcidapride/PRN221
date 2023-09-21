using DataAccessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.DAOs;
    public class SupplierDAO
    {
    private static SupplierDAO? _instance;
    private FucarRentingManagementContext _context;

    private static readonly object _lock = new object();

    public SupplierDAO()
    {
        _context = new FucarRentingManagementContext();
    }
    public static SupplierDAO Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new SupplierDAO();
                }
            }
            return _instance;
        }
    }

    public List<int> GetSupplierIds()
        => _context.Suppliers
        .Select(suppliers => suppliers.SupplierId)
        .ToList();
}

