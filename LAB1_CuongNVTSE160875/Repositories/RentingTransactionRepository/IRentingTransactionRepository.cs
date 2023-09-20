using DataAccessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.CustomerRepository;
public interface IRentingTransactionRepository : IRepository<RentingTransaction>
{
    public static abstract List<RentingDetail>? GetRentingDetails(int id);

    public static abstract List<RentingDetail>? GetMany(int customerId, int pageNumber, int pageSize);
    public static abstract int GetPages(int customerId, int pageSize);
}