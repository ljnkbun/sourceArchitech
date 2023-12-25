using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.ProcessTemplateItems
{
    public class ProcessTemplateItemModel : BaseModel
    {
        public int ProcessTemplateId { get; set; }
        public string Division { get; set; }
        public int Priority { get; set; }
        public bool Deleted { get; set; }

    }
}
