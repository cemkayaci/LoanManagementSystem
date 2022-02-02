using LoanManagementSystem.Common.Config;
using LoanManagementSystem.Common.DataModels;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Domain.Repositories
{
    public class CosmosBaseRepository<T> where T : BaseDataModel
    {
        
        
        private readonly CosmosClient _client;

        private readonly Container _container;

        public CosmosClient Client => _client;

        public Container Container => _container;

        public virtual string ContainerName
        {
            get
            {
                return ApplicationConfig.CosmosDbContainerName;
            }
        }
            
        public CosmosBaseRepository(CosmosClient client)
        {
            _client = client;
            _container = Client.GetContainer(Client.ClientOptions.ApplicationName, ContainerName);
        }
    }
}
