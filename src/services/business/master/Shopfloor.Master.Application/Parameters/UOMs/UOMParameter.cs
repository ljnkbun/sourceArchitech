using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.UOMs   
{
    public class UOMParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ArticleCode { get; set; }
        public int? ArticleId { get; set; }
        public int? DecimalPlaces { get; set; }
        public int? OrderDecimalPlaces { get; set; }
        public string Action { get; set; }
    }
}
