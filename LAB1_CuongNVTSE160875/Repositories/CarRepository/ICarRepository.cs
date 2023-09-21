using DataAccessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.CarRepository;
    public interface ICarRepository : IRepository<CarInformation>
    {
    public static abstract List<int> GetSupplierIds();
    public static abstract List<int> GetManufacturerIds();
}
