using Domain.BackendService.MainService.Contracts;
using Domain.BackendService.MainService.DataMembers;
using MainService.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainService.Service
{
    class ServiceApplication
    {
        private ServiceBusiness _business;
        public ServiceApplication()
        {
            _business = new ServiceBusiness();
        }

        public ResponseDeleteTransaction DeleteTransaction(RequestDeleteTransaction request)
        {
            ResponseDeleteTransaction response = new ResponseDeleteTransaction();

            if (request.Transaction == null)
            {
                throw new ArgumentNullException("Bad Request");
            }
            else if (request.Transaction.ID == 0)
            {
                throw new ArgumentException("Arguments not valid");
            }

            _business.DeleteTransaction(request.Transaction);

            return response;
        }

        public ResponseInsertTransaction InsertTransaction(RequestInsertTransaction request)
        {
            ResponseInsertTransaction response = new ResponseInsertTransaction();

            ValidateTransactionRequest(request.Transaction);

            response.Transaction = _business.InsertTransaction(request.Transaction);

            return response;
        }

        public ResponseSearchTransaction SearchTransaction(RequestSearchTransaction request)
        {
            ResponseSearchTransaction response = new ResponseSearchTransaction();

            if (request.Filter == null)
            {
                throw new ArgumentNullException("Bad Request");
            }

            response.transactions = _business.SearchTransaction(request.Filter);

            foreach (Transaction transaction in response.transactions)
            {
                response.TransactionsTotal += transaction.Value;
            }

            return response;
        }


        private void ValidateTransactionRequest(Transaction transaction)
        {
            bool hadValidateProblem = false;
            string validateProblems = "";
            if (transaction == null)
            {
                throw new ArgumentNullException("Bad Request");
            }
            if (transaction.PayerBank == null || transaction.PayerBank == string.Empty)
            {
                hadValidateProblem = true;
                validateProblems += "Without PayerBank \n";
            }
            if (transaction.PayerBankAccount == null || transaction.PayerBankAccount == string.Empty)
            {
                hadValidateProblem = true;
                validateProblems += "Without PayerBankAccount \n";
            }
            if (transaction.PayerBankAgency == null || transaction.PayerBankAgency == string.Empty)
            {
                hadValidateProblem = true;
                validateProblems += "Without PayerBankAgency \n";
            }
            if (transaction.PayerName == null || transaction.PayerName == string.Empty)
            {
                hadValidateProblem = true;
                validateProblems += "Without PayerName \n";
            }
            if (transaction.RecipientBank == null || transaction.RecipientBank == string.Empty)
            {
                hadValidateProblem = true;
                validateProblems += "Without RecipientBank \n";
            }
            if (transaction.RecipientBankAccount == null || transaction.RecipientBankAccount == string.Empty)
            {
                hadValidateProblem = true;
                validateProblems += "Without RecipientBankAccount \n";
            }
            if (transaction.RecipientBankAgency == null || transaction.RecipientBankAgency == string.Empty)
            {
                hadValidateProblem = true;
                validateProblems += "Without RecipientBankAgency \n";
            }
            if (transaction.RecipientName == null || transaction.RecipientName == string.Empty)
            {
                hadValidateProblem = true;
                validateProblems += "Without RecipientBankAgency \n";
            }
            if (transaction.Value == 0)
            {
                hadValidateProblem = true;
                validateProblems += "Transaction don't have value \n";
            }
            if (transaction.UserID == 0)
            {
                hadValidateProblem = true;
                validateProblems += "Without UserID \n";
            }
            if (transaction.Status != null)
            {
                hadValidateProblem = true;
                validateProblems += "Status must be empty \n";
            }
            if (transaction.TransactionType != null)
            {
                hadValidateProblem = true;
                validateProblems += "TransactionType must be empty \n";
            }
            if (transaction.Date != null)
            {
                hadValidateProblem = true;
                validateProblems += "Date must be empty \n";
            }
            if (hadValidateProblem)
            {
                throw new ArgumentException(validateProblems);
            }
        }


    }
}
