using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Models.DyeingTBRequests
{
    public class DyeingTBRequestModel : BaseModel
    {
        public string RequestNo { get; set; }

        public int RequestType { get; set; }

        public DateTime RequestDate { get; set; }

        public string StyleRef { get; set; }

        public string Remark { get; set; }

        public string Buyer { get; set; }

        public string BuyerRef { get; set; }

        public DateTime ExpiredDate { get; set; }

        public TBRequestStatus Status { get; set; }

        public bool Deleted { get; set; }
    }
}