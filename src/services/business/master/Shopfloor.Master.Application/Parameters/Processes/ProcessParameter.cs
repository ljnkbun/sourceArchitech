using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.Processes
{
    public class ProcessParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
