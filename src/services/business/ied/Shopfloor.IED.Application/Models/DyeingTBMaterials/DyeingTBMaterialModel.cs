using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Application.Models.DyeingTBRequests;

namespace Shopfloor.IED.Application.Models.DyeingTBMaterials
{
    public class DyeingTBMaterialModel : BaseModel
    {
        public int DyeingTBRequestId { get; set; }

        public int WFXArticleId { get; set; }

        public string ArticleCode { get; set; }

        public string ArticleName { get; set; }

        public string MaterialType { get; set; }

        public string FabricStyleRef { get; set; }

        public string FabricContent { get; set; }

        public string Lights { get; set; }

        public DyeingTBRequestModel DyeingTBRequest { get; set; }
    }
}