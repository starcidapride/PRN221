using DataAccessObjects.DAOs;
using DataAccessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.SupplierRepository;
    public class SupplierRepository : ISupplierRepository
    {
    public static bool Update(Supplier entity)
    {
        throw new NotImplementedException();
    }

    public static bool Add(Supplier entity)
    {
        throw new NotImplementedException();
    }

    public static Supplier? Get(int id)
    {
        throw new NotImplementedException();
    }

    public static List<Supplier> GetAll()
    {
        throw new NotImplementedException();
    }

    public static List<int> GetSupplierIds()
        => SupplierDAO.Instance.GetSupplierIds();

    public static bool Delete(Supplier id)
    {
        throw new NotImplementedException();
    }
}

