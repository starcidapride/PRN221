using DataAccessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.DAOs;
    public class ManufacturerDAO
    {
    private static ManufacturerDAO? _instance;
    private FucarRentingManagementContext _context;

    private static readonly object _lock = new object();

    public ManufacturerDAO()
    {
        _context = new FucarRentingManagementContext();
    }
    public static ManufacturerDAO Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new ManufacturerDAO();
                }
            }
            return _instance;
        }
    }

    public List<int> GetManufacturerIds() 
        => _context.Manufacturers
        .Select(manufacturer => manufacturer.ManufacturerId)
        .ToList();
}
