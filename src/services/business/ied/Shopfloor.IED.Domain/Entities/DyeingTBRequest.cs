using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Domain.Entities
{
    public class DyeingTBRequest : BaseEntity
    {
        public DyeingTBRequest()
        {
            DyeingTBMaterials = new HashSet<DyeingTBMaterial>();
            DyeingTBRequestFiles = new HashSet<DyeingTBRequestFile>();
        }

        public string RequestNo { get; set; }

        public int RecipeCategoryId { get; set; }

        public DateTime RequestDate { get; set; }

        public string StyleRef { get; set; }

        public string Remark { get; set; }

        public string Buyer { get; set; }

        public string BuyerRef { get; set; }

        public DateTime ExpiredDate { get; set; }

        public TBRequestStatus Status { get; set; }

        public bool Deleted { get; set; }

        public int? DyeingIEDId { get; set; }

        public virtual ICollection<DyeingTBMaterial> DyeingTBMaterials { get; set; }

        public virtual ICollection<DyeingTBRequestFile> DyeingTBRequestFiles { get; set; }
    }
}