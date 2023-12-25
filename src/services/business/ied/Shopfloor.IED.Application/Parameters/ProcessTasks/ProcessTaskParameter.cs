using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.ProcessTasks
{
    public class ProcessTaskParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
