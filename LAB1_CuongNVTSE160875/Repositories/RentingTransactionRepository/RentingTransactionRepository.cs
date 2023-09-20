using DataAccessObjects.DAOs;
using DataAccessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.CustomerRepository;

public class RentingTransactionRepository : IRentingTransactionRepository
{
    public static bool Add(RentingTransaction entity)
    {
        throw new NotImplementedException();
    }

    public static RentingTransaction? Get(int id)
    {
        throw new NotImplementedException();
    }

    public static List<RentingTransaction> GetMany(int customerId, int pageNumber, int pageSize)
        => RentingTransactionDAO.Instance.GetRentingTransactions(customerId, pageNumber, pageSize);

    public static List<RentingTransaction> GetMany(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public static int GetPages(int customerId, int pageSize) => RentingTransactionDAO.Instance.GetRentingTransactionPages(customerId, pageSize);

    public static List<RentingDetail>? GetRentingDetails(int id) => RentingTransactionDAO.Instance.GetRentingDetails(id);

    public static bool Update(RentingTransaction entity)
    {
        throw new NotImplementedException();
    }

    public static int GetPages(int pageSize)
    {
        throw new NotImplementedException();
    }

    static List<RentingDetail>? IRentingTransactionRepository.GetMany(int customerId, int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }
}