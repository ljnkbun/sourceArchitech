using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Production.Application.Parameters.FPPOOutputs
{
    public class FPPOOutputToDetailsParameter : RequestParameter
    {
        public string OCNo { get; set; }
        public string ArticleName { get; set; }
        public string BatchNo { get; set; }
        public string JobOrderNo { get; set; }
        public string FPPONo { get; set; }
        public decimal? PlannedQty { get; set; }
        public decimal? MadeQty { get; set; }
        public decimal? BalanceQty { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
    }
}
