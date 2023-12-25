using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.DyeingTBMaterialColors
{
    public class DyeingTBMaterialColorSearchParameter : RequestParameter
    {
        public string RequestNo { get; set; }

        public string ArticleCode { get; set; }
    }
}