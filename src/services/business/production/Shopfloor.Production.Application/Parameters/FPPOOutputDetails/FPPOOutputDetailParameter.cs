using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Production.Application.Parameters.FPPOOutputDetails
{
    public class FPPOOutputDetailParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? FPPOOutputId { get; set; }
        public decimal? PlannedQty { get; set; }
        public decimal? MadeQty { get; set; }
        public decimal? BalanceQty { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
    }
}
