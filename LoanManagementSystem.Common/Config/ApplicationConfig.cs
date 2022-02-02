using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Common.Config
{
    public class ApplicationConfig
    {
        private static string _cosmosDbEndpoint;

        private static string _cosmosDbAccountKey;

        private static string _cosmosDbName;
        private static string _cosmosDbContainerName;
        private static string _sqlConnectionString;

        public static void SetAppSettingsProperties(IConfiguration configuration)
        {
            _cosmosDbEndpoint = configuration.GetSection("DatabaseEndpoint").Value;
            _cosmosDbAccountKey = configuration.GetSection("DatabaseAccountKey").Value;
            _cosmosDbName = configuration.GetSection("DatabaseName").Value;
            _cosmosDbContainerName = configuration.GetSection("ContainerName").Value;
            _sqlConnectionString = configuration.GetConnectionString("SqlServerConnectionString");
        }

        public static string CosmosDbEndpoint => _cosmosDbEndpoint;
        public static string CosmosDbAccountKey => _cosmosDbAccountKey;
        public static string CosmosDbName => _cosmosDbName;
        public static string CosmosDbContainerName => _cosmosDbContainerName;
        public static string SqlConnectionString => _sqlConnectionString;
    }

}
