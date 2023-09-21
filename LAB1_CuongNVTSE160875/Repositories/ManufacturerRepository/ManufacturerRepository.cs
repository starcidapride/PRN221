using DataAccessObjects.DAOs;
using DataAccessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.ManufacturerRepository;
public class ManufacturerRepository : IManufacturerRepository
{
    public static bool Add(Manufacturer entity)
    {
        throw new NotImplementedException();
    }

    public static Manufacturer? Get(int id)
    {
        throw new NotImplementedException();
    }

    public static List<Manufacturer> GetAll()
    {
        throw new NotImplementedException();
    }

    public static bool Update(Manufacturer entity)
    {
        throw new NotImplementedException();
    }

    public static List<int> GetManufacturerIds() => ManufacturerDAO.Instance.GetManufacturerIds();

    public static bool Delete(Manufacturer id)
    {
        throw new NotImplementedException();
    }
}
