using Domain.BackendService.MainService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointService.Controllers.v1
{
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        private Uri uri = new Uri("fabric:/BackendServiceFabricSample/MainService");
        private IMainService _service;

        protected IMainService Service
        {
            get
            {
                if (_service == null)
                    _service = ServiceProxy.Create<IMainService>(uri, new ServicePartitionKey(1));

                return _service;
            }
        }
    }
}
