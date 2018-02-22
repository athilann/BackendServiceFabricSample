using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.BackendService.MainService;
using Domain.BackendService.MainService.Contracts;
using MainService.Service;
using Microsoft.ServiceFabric.Data.Collections;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace MainService
{
    /// <summary>
    /// An instance of this class is created for each service replica by the Service Fabric runtime.
    /// </summary>
    internal sealed class MainService : StatefulService , IMainService
    {
        private ServiceApplication _service;
        public MainService(StatefulServiceContext context)
            : base(context)
        {
            _service = new ServiceApplication();
        }

        public Task<ResponseDeleteTransaction> DeleteTransaction(RequestDeleteTransaction request)
        {
            return Task.Run(() => {
                return _service.DeleteTransaction(request);
            });
        }

        public Task<ResponseInsertTransaction> InsertTransaction(RequestInsertTransaction request)
        {
            return Task.Run(() => {
                return _service.InsertTransaction(request);
            });
        }

        public Task<ResponseSearchTransaction> SearchTransaction(RequestSearchTransaction request)
        {
            return Task.Run(() => {
                return _service.SearchTransaction(request);
            });
        }

        /// <summary>
        /// Optional override to create listeners (e.g., HTTP, Service Remoting, WCF, etc.) for this service replica to handle client or user requests.
        /// </summary>
        /// <remarks>
        /// For more information on service communication, see https://aka.ms/servicefabricservicecommunication
        /// </remarks>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            return new[] { new ServiceReplicaListener(context => this.CreateServiceRemotingListener(context)) };
        }

    }
}
