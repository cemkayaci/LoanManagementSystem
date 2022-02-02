using Newtonsoft.Json;


namespace LoanManagementSystem.Common.DataModels
{
    public class BaseDataModel 
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
