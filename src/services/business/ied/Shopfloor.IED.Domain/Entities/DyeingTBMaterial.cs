using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class DyeingTBMaterial : BaseEntity
    {
        public DyeingTBMaterial()
        {
            DyeingTBMaterialColors = new HashSet<DyeingTBMaterialColor>();
        }

        public int DyeingTBRequestId { get; set; }

        public int WFXArticleId { get; set; }

        public string ArticleCode { get; set; }

        public string ArticleName { get; set; }

        public string FabricStyleRef { get; set; }

        public string MaterialType { get; set; }

        public string FabricContent { get; set; }

        public string Lights { get; set; }

        public virtual DyeingTBRequest DyeingTBRequest { get; set; }

        public virtual ICollection<DyeingTBMaterialColor> DyeingTBMaterialColors { get; set; }
    }
}