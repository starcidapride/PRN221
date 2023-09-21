using DataAccessObjects.DAOs;
using DataAccessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.CustomerRepository;

public class RentingDetailsRepository : IRentingDetailsRepository
{
    public static bool Update(RentingDetail entity)
    {
        throw new NotImplementedException();
    }

    public static bool Add(RentingDetail entity)
    {
        throw new NotImplementedException();
    }

    static RentingDetail? IRepository<RentingDetail>.Get(int id)
    {
        throw new NotImplementedException();
    }

    public static bool Delete(RentingDetail entity)
    {
        throw new NotImplementedException();
    }

    public static List<RentingDetail> GetAll(DateTime startDate, DateTime endDate, bool startOrEnd)
        => RentingTransactionDAO.Instance.GetRentingDetails(startDate, endDate, startOrEnd);

    public static List<RentingDetail>? GetRentingDetails(int id)
    {
        throw new NotImplementedException();
    }

    public static List<RentingDetail> GetAll()
    {
        throw new NotImplementedException();
    }
}