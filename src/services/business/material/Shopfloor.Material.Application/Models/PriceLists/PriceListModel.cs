using Shopfloor.Core.Models.Entities;
using Shopfloor.Material.Application.Models.PriceListDetails;
using Shopfloor.Material.Domain.Enums;

namespace Shopfloor.Material.Application.Models.PriceLists
{
    public class PriceListModel : BaseModel
    {
        public string RequestNo { get; set; }

        public string CategoryCode { get; set; }

        public string CategoryName { get; set; }

        public string SupplierCode { get; set; }

        public string SupplierName { get; set; }

        public ProcessStatus Status { get; set; }

        public Guid? ApproveUserId { get; set; }

        public string ApproveName { get; set; }

        public string ReasonReject { get; set; }

        public ICollection<PriceListDetailModel> PriceListDetails { get; set; }
    }
}