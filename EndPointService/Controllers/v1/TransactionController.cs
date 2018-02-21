using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.BackendService.MainService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EndPointService.Controllers.v1
{
    [Route("api/v1/transaction/[controller]")]
    [ExceptionHandlerFilter]
    public class ClientTransactionController : BaseController
    {
        [HttpPost("InsertTransaction")]
        public ResponseInsertTransaction InsertTransaction([FromBody]RequestInsertTransaction request)
        {
            return Task.Run(async () => await Service.InsertTransaction(request)).Result;
        }

        [HttpGet("SearchTransaction")]
        public ResponseSearchTransaction SearchTransaction([FromQuery]RequestSearchTransaction request)
        {
            return Task.Run(async () => await Service.SearchTransaction(request)).Result;
        }

        [HttpDelete("DeleteMachine")]
        public ResponseDeleteTransaction DeleteMachine([FromBody]RequestDeleteTransaction request)
        {
            return Task.Run(async () => await Service.DeleteTransaction(request)).Result;
        }
    }
}