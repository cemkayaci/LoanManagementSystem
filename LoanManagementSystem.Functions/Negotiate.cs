
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Functions
{
    public static class Negotiate
    {
        [FunctionName("negotiate")]
        public static SignalRConnectionInfo Run(
            [HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequest req,
            [SignalRConnectionInfo(HubName = "loanmanagementhub")] SignalRConnectionInfo connectionInfo)
        {
            return connectionInfo;
        }
    }
}
