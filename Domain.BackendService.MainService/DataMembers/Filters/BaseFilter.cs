using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BackendService.MainService.DataMembers.Filters
{
    public class BaseFilter
    {
        public int StartSearchRecordNumber { get; set; }

        private int quantityOfRecords = 100;

        public int QuantityOfRecords
        {
            get { return quantityOfRecords; }
            set
            {
                quantityOfRecords = Math.Min(100, value);
            }
        }
    }
}
