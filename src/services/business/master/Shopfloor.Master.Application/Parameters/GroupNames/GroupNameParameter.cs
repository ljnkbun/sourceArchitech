using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.GroupNames
{
    public class GroupNameParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
