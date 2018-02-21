using Domain.BackendService.MainService.Contracts;
using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BackendService.MainService
{
    public interface IMainService : IService
    {
        Task<ResponseInsertTransaction> InsertTransaction(RequestInsertTransaction request);
        Task<ResponseSearchTransaction> SearchTransaction(RequestSearchTransaction request);
        Task<ResponseDeleteTransaction> DeleteTransaction(RequestDeleteTransaction request);
    }
}
