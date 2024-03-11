using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Models.DyeingIEDs
{
    public class DyeingIEDModel : BaseModel
    {
        public int RequestArticleOutputId { get; set; }

        public string RequestNo { get; set; }
        public string RequestType { get; set; }

        public int? RequestTypeId { get; set; }

        public int WFXArticleId { get; set; }

        public string ArticleCode { get; set; }

        public string ArticleName { get; set; }

        public string ProductGroup { get; set; }

        public string SubCategory { get; set; }

        public string Buyer { get; set; }

        public string Color { get; set; }

        public string ColorRef { get; set; }

        public int? RecipeId { get; set; }

        public Status Status { get; set; }

        public string Comment { get; set; }
        public string RejectReason { get; set; }
		public DateTime ExpectedDate { get; set; }
        public decimal? ExpectedQty { get; set; }
        public string TCFNo { get; set; }
        public int? WFXInputMaterialId { get; set; }
        public string InputMaterialName { get; set; }
    }
}