using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.AccountGroups
{
    public class AccountGroupParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
