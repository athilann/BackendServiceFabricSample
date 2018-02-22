using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.BackendService.MainService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EndPointService.Controllers.v1
{
    [Route("api/v1/Client/[controller]")]
    [ExceptionHandlerFilter]
    public class TransactionController : BaseController
    {
        [HttpPost("Insert")]
        public ResponseInsertTransaction Insert([FromBody]RequestInsertTransaction request)
        {
            return Task.Run(async () => await Service.InsertTransaction(request)).Result;
        }

        [HttpGet("Search")]
        public ResponseSearchTransaction Search([FromQuery]RequestSearchTransaction request)
        {
            return Task.Run(async () => await Service.SearchTransaction(request)).Result;
        }

        [HttpDelete("Delete")]
        public ResponseDeleteTransaction Delete([FromBody]RequestDeleteTransaction request)
        {
            return Task.Run(async () => await Service.DeleteTransaction(request)).Result;
        }
    }
}