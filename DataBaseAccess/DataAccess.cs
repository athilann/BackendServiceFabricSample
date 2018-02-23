using DataBaseAccess.Context;
using DataBaseAccess.Entity;
using DataBaseAccess.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccess
{
    public class DataAccess
    {

        public DataAccess()
        {
            using (var dbContext = new DataContext())
            {
                dbContext.Database.Migrate();
            }
        }

        public void DeleteTransaction(Transaction transaction)
        {
            using (var dbContext = new DataContext())
            {
                Transaction transactionToDelete = dbContext.Transactions.FirstOrDefault(t => t.TransactionID == transaction.TransactionID );
                if (transactionToDelete == null)
                {
                    throw new ArgumentException("Transaction not found");
                }
                transactionToDelete.Active = 0;
                dbContext.Update(transactionToDelete);
                dbContext.SaveChanges();
            }
        }

        public Transaction InsertTransaction(Transaction transaction)
        {
            using (var dbContext = new DataContext())
            {
                dbContext.Transactions.Add(transaction);
                dbContext.SaveChanges();
                return transaction;
            }
        }

        public List<Transaction> SearchTransaction(TransactionFilter filter)
        {
            using (var dbContext = new DataContext())
            {
                IQueryable<Transaction> query = dbContext.Transactions;

                if (filter.ByID > 0)
                    query = query.Where(p => p.TransactionID == filter.ByID);

                if (!string.IsNullOrEmpty(filter.ByPayerBank))
                    query = query.Where(p => p.PayerBank.Contains(filter.ByPayerBank));

                if (!string.IsNullOrEmpty(filter.ByPayerBankAccount))
                    query = query.Where(p => p.PayerBankAccount.Contains(filter.ByPayerBankAccount));

                if (!string.IsNullOrEmpty(filter.ByPayerBankAgency))
                    query = query.Where(p => p.PayerBankAgency.Contains(filter.ByPayerBankAgency));

                if (!string.IsNullOrEmpty(filter.ByPayerName))
                    query = query.Where(p => p.PayerName.Contains(filter.ByPayerName));

                if (!string.IsNullOrEmpty(filter.ByRecipientBank))
                    query = query.Where(p => p.RecipientBank.Contains(filter.ByRecipientBank));

                if (!string.IsNullOrEmpty(filter.ByRecipientBankAccount))
                    query = query.Where(p => p.RecipientBankAccount.Contains(filter.ByRecipientBankAccount));

                if (!string.IsNullOrEmpty(filter.ByRecipientBankAgency))
                    query = query.Where(p => p.RecipientBankAgency.Contains(filter.ByRecipientBankAgency));

                if (!string.IsNullOrEmpty(filter.ByRecipientName))
                    query = query.Where(p => p.RecipientName.Contains(filter.ByRecipientName));

                if (filter.ByDateRange.Start.HasValue)
                    query = query.Where(p => p.Date >= filter.ByDateRange.Start);

                if (filter.ByDateRange.End.HasValue)
                    query = query.Where(p => p.Date <= filter.ByDateRange.End);

                query = query.OrderBy(p => p.TransactionID).OrderByDescending(p => p.Date);
                query = query.Skip(filter.StartSearchRecordNumber).Take(filter.QuantityOfRecords);

                return query.ToList();
            }
        }


    }
}
