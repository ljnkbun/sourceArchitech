using Newtonsoft.Json;

namespace Shopfloor.Ambassador.Application.Models
{
    public class WfxMasterData
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        public int? SortOrder { get; set; }
        public int? InsertedOrderID { get; set; }
        [JsonProperty("disable")]
        public bool Disable { get; set; }
    }
}
