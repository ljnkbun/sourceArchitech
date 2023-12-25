using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Material.Application.Models.SupplierWisePurchaseOptions
{
    public class SupplierWisePurchaseOptionModel : BaseModel
    {
        public int MaterialRequestId { get; set; }

        public string MoqRoundingTypeId { get; set; }

        public string SupplierId { get; set; }

        public string Moq { get; set; }

        public string MoqSurChargeValue { get; set; }

        public string MoqSurchargeCurrency { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        public string Mcq { get; set; }

        public string McqSurchargeValue { get; set; }

        public string McqSurchargeCurrency { get; set; }
    }
}