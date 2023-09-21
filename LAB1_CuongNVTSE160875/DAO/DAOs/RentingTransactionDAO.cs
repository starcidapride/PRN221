using DataAccessObjects.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects.DAOs;
    public class RentingTransactionDAO
    {
        private static RentingTransactionDAO? _instance;
        private FucarRentingManagementContext _context;

        private static readonly object _lock = new object();

        public RentingTransactionDAO()
        {
            _context = new FucarRentingManagementContext();
        }
    public static RentingTransactionDAO Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new RentingTransactionDAO();
                }
            }
            return _instance;
        }
    }

    public List<RentingTransaction> GetRentingTransactions(int customerId) =>
        _context.RentingTransactions
        .Where(transaction => transaction.CustomerId == customerId)
        .ToList();
    public List<RentingTransaction> GetRentingTransactions() =>
    _context.RentingTransactions
    .ToList();

    public List<RentingDetail> GetRentingDetails(DateTime startDate, DateTime endDate, bool startOrEnd)
    {
        var query = _context.RentingDetails.AsQueryable();

        if (startOrEnd)
        {
            query = query.Where(details => details.StartDate >= startDate && details.StartDate <= endDate)
                         .OrderByDescending(details => details.StartDate);
        }
        else
        {
            query = query.Where(details => details.EndDate >= startDate && details.EndDate <= endDate)
                         .OrderByDescending(details => details.EndDate);
        }

        return query.ToList();
    }

    public bool DeleteRentingTransaction(RentingTransaction trans)
    {
        try
        {
            _context.Entry(trans).Collection(rt => rt.RentingDetails).Load();
            _context.RentingDetails.RemoveRange(trans.RentingDetails);

            _context.RentingTransactions.Remove(trans);
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

    public List<RentingDetail>? GetRentingDetails(int id)
    {
        Trace.WriteLine(JsonConvert.SerializeObject(_context.RentingTransactions
        .FirstOrDefault(transaction => transaction.RentingTransationId == id)));

        return _context.RentingTransactions
        .Include(transaction => transaction.RentingDetails)
        .FirstOrDefault(transaction => transaction.RentingTransationId == id)?
        .RentingDetails.ToList();
    }
}
