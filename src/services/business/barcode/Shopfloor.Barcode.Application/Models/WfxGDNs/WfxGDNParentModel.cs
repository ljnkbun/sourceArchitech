using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Application.Models.WfxGDNs
{
    public class WfxGDNParentModel : BaseModel
    {
        public WfxGDNParentModel()
        {
            WfxGDNChildModels = new List<WfxGDNChildModel>();
        }
        public string GDNNum { get; set; }
        public DateTime? GDNCreationDate { get; set; }
        public string GDNType { get; set; }
        public string OrderRefNum { get; set; }
        public string GDINum { get; set; }
        public DateTime? OrderCreationDate { get; set; }
        public string WFXArticleCode { get; set; }
        public string WFXArticleName { get; set; }
        public string Location { get; set; }
        public int? LocationId { get; set; }
        public string WareHouse { get; set; }
        public string InternalShade { get; set; }
        public virtual ICollection<WfxGDNChildModel> WfxGDNChildModels { get; set; }
    }
}

