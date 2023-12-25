using Shopfloor.Core.Models.Parameters;
using Shopfloor.Material.Domain.Enums;

namespace Shopfloor.Material.Application.Parameters.PriceLists
{
    public class PriceListParameter : RequestParameter
    {
        public string RequestNo { get; set; }

        public string CategoryCode { get; set; }

        public string CategoryName { get; set; }

        public string SupplierCode { get; set; }

        public string SupplierName { get; set; }

        public ProcessStatus? Status { get; set; }

        public Guid? ApproveUserId { get; set; }

        public string ApproveName { get; set; }

        public string ReasonReject { get; set; }

        public DateTime? CreatedFrom { get; set; }

        public DateTime? CreatedTo { get; set; }
    }
}