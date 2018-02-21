using Domain.BackendService.MainService.DataMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BackendService.MainService.Contracts
{
    public class ResponseSearchTransaction
    {
        public List<Transaction> transactions { get; set; }
        public decimal TransactionsTotal { get; set; }
    }
}
