using Domain.BackendService.MainService.DataMembers;
using Domain.BackendService.MainService.DataMembers.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BackendService.MainService.Contracts
{
    public class RequestSearchTransaction
    {
        public TransactionFilter Filter { get; set; }
    }
}
