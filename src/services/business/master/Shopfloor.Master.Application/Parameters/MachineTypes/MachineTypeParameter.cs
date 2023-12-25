using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.MachineTypes
{
    public class MachineTypeParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
