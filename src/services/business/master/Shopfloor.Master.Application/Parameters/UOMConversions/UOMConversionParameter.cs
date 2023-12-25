using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.UOMConversions
{
    public class UOMConversionParameter : RequestParameter
    {
        public int? FromUOMId { get; set; }
        public int? ToUOMId { get; set; }
        public decimal? Value { get; set; }
        public string Action { get; set; }

    }
}
