using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.SpinningProcesses
{
    public class SpinningProcessParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
