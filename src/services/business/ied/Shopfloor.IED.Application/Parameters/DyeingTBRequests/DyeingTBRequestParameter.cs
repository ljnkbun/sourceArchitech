using Shopfloor.Core.Models.Parameters;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Parameters.DyeingTBRequests
{
    public class DyeingTBRequestParameter : RequestParameter
    {
        public string RequestNo { get; set; }

        public int? RecipeCategoryId { get; set; }

        public DateTime? RequestDate { get; set; }

        public string StyleRef { get; set; }

        public string Remark { get; set; }

        public int? DyeingIEDId { get; set; }

        public string Buyer { get; set; }

        public string BuyerRef { get; set; }

        public DateTime? ExpiredDate { get; set; }

        public TBRequestStatus? Status { get; set; }
    }
}