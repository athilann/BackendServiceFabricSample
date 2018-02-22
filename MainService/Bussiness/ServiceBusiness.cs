using Domain.BackendService.MainService.DataMembers;
using Domain.BackendService.MainService.DataMembers.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainService.Bussiness
{
    class ServiceBusiness
    {

        private DataAccess.DataAccess dataAccess;
        public ServiceBusiness()
        {
            dataAccess = new DataAccess.DataAccess();
        }

        public void DeleteTransaction(Transaction transaction)
        {
            dataAccess.DeleteTransaction(transaction);
        }

        public Transaction InsertTransaction(Transaction transaction)
        {
            if (transaction.Value > 100000)
            {
                throw new ArgumentException("Transaction with a value greater than R$ 10.000,00");
            }

            transaction.Date = DateTime.Now;

            if (transaction.PayerBank.Equals(transaction.RecipientBank))
            {
                transaction.TransactionType = "CC";
            }
            else if (transaction.Value <= 5000 && ((transaction.Date?.Hour >= 10) && (transaction.Date?.Hour < 16)))
            {
                transaction.TransactionType = "TED";
            }
            else
            {
                transaction.TransactionType = "DOC";
            }

            return dataAccess.InsertTransaction(transaction);

        }

        public List<Transaction> SearchTransaction(TransactionFilter filter)
        {
            return dataAccess.SearchTransaction(filter);
        }

    }
}
