using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.DyeingTBMaterials
{
    public class DyeingTBMaterialParameter : RequestParameter
    {
        public int? DyeingTBRequestId { get; set; }

        public int WFXArticleId { get; set; }

        public string ArticleCode { get; set; }

        public string ArticleName { get; set; }

        public string MaterialType { get; set; }

        public string FabricStyleRef { get; set; }

        public string FabricContent { get; set; }

        public string Lights { get; set; }
    }
}