using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.DCTemplateDetails
{
    public class DCTemplateDetailModel : BaseModel
    {
        public int DCTemplateTaskId { get; set; }

        public string ChemicalCode { get; set; }

        public string ChemicalName { get; set; }

        public string Unit { get; set; }

        public decimal Value { get; set; }

        public int LineNumber { get; set; }
    }
}