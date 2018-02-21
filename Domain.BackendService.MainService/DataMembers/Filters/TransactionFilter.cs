using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BackendService.MainService.DataMembers.Filters
{
    public class TransactionFilter:BaseFilter
    {
        public int ByID { get; set; }
        public DateRange ByDateRange { get; set; }
        public string ByPayerName { get; set; }
        public string ByPayerBank { get; set; }
        public string ByPayerBankAgency { get; set; }
        public string ByPayerBankAccount { get; set; }
        public string ByRecipientName { get; set; }
        public string ByRecipientBank { get; set; }
        public string ByRecipientBankAgency { get; set; }
        public string ByRecipientBankAccount { get; set; }
    }
    public class DateRange
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}
