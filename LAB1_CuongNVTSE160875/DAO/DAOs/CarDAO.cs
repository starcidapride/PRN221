using DataAccessObjects.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DataAccessObjects.DAOs;
    public class CarDAO
    {
    private static CarDAO? _instance;
    private FucarRentingManagementContext _context;

    private static readonly object _lock = new object();

    public CarDAO()
    {
        _context = new FucarRentingManagementContext();
    }
    public static CarDAO Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new CarDAO();
                }
            }
            return _instance;
        }
    }

    public CarInformation? GetCarById(int id) => _context.CarInformations.FirstOrDefault(car => car.CarId == id);
    public List<CarInformation> GetCars() => _context.CarInformations.ToList();

    public List<CarInformation> GetCars(string searchValue) => _context.CarInformations.Where(car => car.CarName.Contains(searchValue)).ToList();

    public bool UpdateCar(CarInformation car)
    {
        try
        {
            _context.CarInformations.Update(car);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return true;

        }
        catch (Exception ex)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt"), true))
            {
                outputFile.WriteLine(ex.Message);
            }
            return false;
        }
    }

    public bool AddCar(CarInformation car)
    {
        try
        {
            _context.CarInformations.Add(car);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return true;

        }
        catch (Exception ex)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt"), true))
            {
                outputFile.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return false;
        }
    }


}
