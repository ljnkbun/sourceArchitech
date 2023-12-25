using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Models.DyeingTBRecipes
{
    public class DyeingTBRecipeModel : BaseModel
    {
        public int DyeingTBMaterialColorId { get; set; }

        public string TBRecipeNo { get; set; }

        public int TemplateId { get; set; }

        public string TemplateName { get; set; }

        public string TCFNo { get; set; }

        public int ApproveVersionId { get; set; }

        public DateTime ApproveDate { get; set; }

        public string Comment { get; set; }

        public string Buyer { get; set; }

        public string BuyerRef { get; set; }

        public string GarmentStyleRef { get; set; }

        public DateTime ExpectedDate { get; set; }

        public string Color { get; set; }

        public string Concentration { get; set; }

        public int VersionQty { get; set; }

        public TBRecipeStatus Status { get; set; }
    }
}