using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.DCTemplateDetails
{
    public class DCTemplateDetailParameter : RequestParameter
    {
        public int? DCTemplateTaskId { get; set; }
        public int? ChemicalId { get; set; }
        public string ChemicalSubCategory { get; set; }
        public string ChemicalCode { get; set; }

        public string ChemicalName { get; set; }

        public string Unit { get; set; }

        public decimal? Value { get; set; }

        public int? LineNumber { get; set; }
    }
}