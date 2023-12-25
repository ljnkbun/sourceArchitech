using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.Counts
{
    public class CountParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
