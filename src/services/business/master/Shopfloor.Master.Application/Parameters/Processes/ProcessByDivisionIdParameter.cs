using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.Processes
{
    public class ProcessByDivisionIdParameter : RequestParameter
    {
        public int? DivisionId { get; set; }
        public string DivisionCode { get; set; }
    }
}