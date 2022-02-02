using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;

using Microsoft.Extensions.Logging;
using System.Text.Json;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using LoanManagementSystem.Common.DataModels.Loan;

namespace LoanManagementSystem.Functions
{
    public static class LoanTrigger
    {
       [FunctionName("LoanTrigger")]
       public static async Task Run([CosmosDBTrigger(
           databaseName: "LoanManagementSystem",
           collectionName: "loan",
           ConnectionStringSetting = "CosmosDbConnectionString",
           LeaseCollectionName = "leases",CreateLeaseCollectionIfNotExists=true)]IReadOnlyList<Document> input, ILogger log,
           [SignalR(HubName = "loanmanagementhub")] IAsyncCollector<SignalRMessage> signalRMessages)
           {         
               try
               {                    
                   
                if (input != null && input.Count > 0)
                {
                    log.LogInformation("Documents modified " + input.Count);                

                    foreach (Document document in input)
                    {
                        LoanModel item = (dynamic)document;
                        await signalRMessages.AddAsync(new SignalRMessage
                        {
                            Target = "target",
                            Arguments = new[] { item }
                        });
                    }
                 }
               }
               catch (Exception ex)
               {
                   log.LogError(ex.Message);
               }
        }
    }
}
