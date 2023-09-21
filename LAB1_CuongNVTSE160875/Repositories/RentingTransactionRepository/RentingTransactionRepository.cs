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

    public static List<RentingDetail>? GetRentingDetails(int id) => RentingTransactionDAO.Instance.GetRentingDetails(id);

    public static bool Update(RentingTransaction entity)
    {
        throw new NotImplementedException();
    }

    public static int GetPages(int pageSize)
    {
        throw new NotImplementedException();
    }

    public static List<RentingTransaction>? GetMany(int customerId)
        => RentingTransactionDAO.Instance.GetRentingTransactions(customerId);

    public static List<RentingTransaction> GetAll()
        => RentingTransactionDAO.Instance.GetRentingTransactions();

    public static bool Delete(RentingTransaction id)
        => RentingTransactionDAO.Instance.DeleteRentingTransaction(id);

    public static int GetPages(int customerId, int pageSize)
    {
        throw new NotImplementedException();
    }
}