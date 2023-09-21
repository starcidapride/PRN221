using DataAccessObjects.DAOs;
using DataAccessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.CarRepository
{
    public class CarRepository : ICarRepository
    {
        public static bool Add(CarInformation entity) 
            => CarDAO.Instance.AddCar(entity);

        public static bool Delete(CarInformation id)
        {
            throw new NotImplementedException();
        }

        public static CarInformation? Get(int id) => CarDAO.Instance.GetCarById(id);

        public static List<CarInformation> GetAll() => CarDAO.Instance.GetCars();

        public static List<int> GetManufacturerIds()
        {
            throw new NotImplementedException();
        }

        public static List<CarInformation> GetMany(string searchValue) => CarDAO.Instance.GetCars(searchValue);
        public static int GetPages(int pageSize)
        {
            throw new NotImplementedException();
        }

        public static List<int> GetSupplierIds()
        {
            throw new NotImplementedException();
        }

        public static bool Update(CarInformation entity)
            => CarDAO.Instance.UpdateCar(entity);
    }
}
