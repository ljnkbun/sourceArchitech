using Shopfloor.Core.Models.Entities;
using Shopfloor.Planning.Application.Models.StripFactories;

namespace Shopfloor.Planning.Application.Models.StripSchedules
{
    public class StripSheduleHistoryModel : BaseModel
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string LineName { get; set; }
        public string MachineName { get; set; }

        /// <summary>
        /// POR
        /// </summary>
        public string OCNo { get; set; }
        public string PORNo { get; set; }
        public string DivisionName { get; set; }
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public string Buyer { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string ProductGroup { get; set; }
        public string BOMNo { get; set; }
        public decimal Quantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public string ProcessName { get; set; }
    }
}
