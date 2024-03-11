using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Planning.Application.Parameters.FactoryCapacitys
{
    public class FactoryCapacityParameter : RequestParameter
    {
        public int? FactoryId { get; set; }
        public int? ProcessId { get; set; }
		public DateTime FromDate { get; set; }
		public DateTime ToDate { get; set; }
        public string PorNo {  get; set; }
    }
}
