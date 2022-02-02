using LoanManagementSystem.Common.Config;
using LoanManagementSystem.Domain.DbConnectionFactory.Cosmos.Contracts;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Domain.DbConnectionFactory.Cosmos
{
    public class CosmosDbClientFactory : ICosmosDbClientFactory
    {        
        public CosmosClient NewCosmosClient()
        {
            CosmosClientBuilder builder = new CosmosClientBuilder(ApplicationConfig.CosmosDbEndpoint, ApplicationConfig.CosmosDbAccountKey);
            return builder
                .WithConnectionModeDirect()
                .WithApplicationName(ApplicationConfig.CosmosDbName)
                .WithSerializerOptions(new CosmosSerializationOptions { PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase })
                .Build();
        }
    }
}
