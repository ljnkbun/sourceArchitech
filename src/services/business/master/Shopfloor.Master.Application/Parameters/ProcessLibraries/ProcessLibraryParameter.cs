using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.ProcessLibraries
{
    public class ProcessLibraryParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
