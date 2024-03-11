using Shopfloor.Core.Models.Entities;
using System.Text.Json.Serialization;

namespace Shopfloor.Planning.Application.Models.Articles
{
    public class ArticleHistoryModel : BaseModel
    {
        /// <summary>
        /// Relation
        /// </summary>
        public int StripFactoryId { get; set; }
        public int PlanningGroupFactoryId { get; set; }

        /// <summary>
        /// StripShedule
        /// </summary>
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        [JsonIgnore]
        public int? LineId { get; set; }
        public string LineName { get; set; }
        [JsonIgnore]
        public int? MachineId { get; set; }

        public string MachineName { get; set; }

        /// <summary>
        /// POR
        /// </summary>
        public string OCNo { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string PORNo { get; set; }
        public string DivisionName { get; set; }
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public string Buyer { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string ProductGroup { get; set; }
        public string BOMNo { get; set; }
        public string FactoryName { get; set; }
        public string ProcessName { get; set; }
        public decimal Quantity { get; set; }
        public decimal RemainingQuantity { get; set; }

        /// <summary>
        /// StripShedulePlanning
        /// </summary>
        public decimal ReceivedCapacity { get; set; }
    }
}
