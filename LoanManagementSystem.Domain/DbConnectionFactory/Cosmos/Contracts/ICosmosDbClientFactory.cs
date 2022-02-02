using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Domain.DbConnectionFactory.Cosmos.Contracts
{
    public interface ICosmosDbClientFactory
    {
        CosmosClient NewCosmosClient();
    }
}
