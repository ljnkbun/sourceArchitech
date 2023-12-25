using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Material.Application.Models.Buyers
{
    public class BuyerImportExcelModel : BaseModel
    {
        #region Properties

        public string RequestNo { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Address { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public string BillAddress { get; set; }

        public string ShipAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public string Telephone { get; set; }

        public string Currency { get; set; }

        public string BuyerType { get; set; }

        public string ContactFirstName { get; set; }

        public string ContactLastName { get; set; }

        public string ContactEmail { get; set; }

        public decimal? Tolearance { get; set; }

        public string PaymentTerms { get; set; }

        public string DeliveryTerms { get; set; }

        public string ShipmentTerms { get; set; }

        public string FinalDestination { get; set; }

        public string CountryOfFinalDestination { get; set; }

        public string PortofDischarge { get; set; }

        public string GroupNameCode { get; set; }

        public string AccountGroup { get; set; }

        public string Category { get; set; }

        public string PAN { get; set; }

        public string TIN { get; set; }

        public string Market { get; set; }

        public string CustomHouse { get; set; }

        public string BankAccountNumber { get; set; }

        public string BankAddress { get; set; }

        public string VATNumber { get; set; }

        public string SwiftCode { get; set; }

        public string Department { get; set; }

        public decimal? MaximumOutAmount { get; set; }

        #endregion Properties

        #region Extend

        public string BusinessSegment { get; set; }

        public string ProductCategory { get; set; }

        #endregion Extend
    }
}