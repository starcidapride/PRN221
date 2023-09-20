using DataAccessObjects.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public List<RentingTransaction> GetRentingTransactions(int customerId, int pageNumber, int pageSize) =>
        _context.RentingTransactions
        .Where(transaction => transaction.CustomerId == customerId)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize).ToList();

    public int GetRentingTransactionPages(int customerId, int pageSize) 
        => _context.RentingTransactions.Where(transaction => transaction.CustomerId == customerId).Count() / pageSize + 1;

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
