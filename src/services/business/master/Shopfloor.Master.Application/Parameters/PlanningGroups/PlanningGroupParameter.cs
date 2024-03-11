using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.PlanningGroups
{
    public class PlanningGroupParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? ProcessId { get; set; }
        public int? CalendarId { get; set; }
    }
}
