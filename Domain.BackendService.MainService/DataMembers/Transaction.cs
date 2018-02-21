using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BackendService.MainService.DataMembers
{
    public class Transaction
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string PayerName { get; set; }
        public string PayerBank { get; set; }
        public string PayerBankAgency { get; set; }
        public string PayerBankAccount { get; set; }
        public string RecipientName { get; set; }
        public string RecipientBank { get; set; }
        public string RecipientBankAgency { get; set; }
        public string RecipientBankAccount { get; set; }
        public decimal Value { get; set; }
        public string TransactionType { get; set; }
        public string Status { get; set; }
    }
}
