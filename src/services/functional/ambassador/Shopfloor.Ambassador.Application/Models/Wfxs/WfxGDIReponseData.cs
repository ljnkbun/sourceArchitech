using Newtonsoft.Json;
using System.Globalization;

namespace Shopfloor.Ambassador.Application.Models.Wfxs
{
    public class WfxGDIReponseData
    {
        public int? ResponseID { get; set; }
        public string ErrorMsg { get; set; }
        public List<WfxGDIResponse> ResponseData { get; set; }
        public string Status { get; set; }
    }

    public class WfxGDIResponse
    {
        public string GDINum { get; set; }
        [JsonProperty("gDICreationDate")]
        public string GDICreationDate { get; set; }

        public DateTime? gDICreationDate
        {
            get { return DateTime.Parse(GDICreationDate, new CultureInfo("en-US")); }
        }
        public List<WfxGDIData> OrderData { get; set; }
    }

    public class WfxGDIData
    {
        public string GDINum { get; set; } 
        public string GDIType { get; set; }
        public string OrderRefNum { get; set; }
        public DateTime? OrderCreationDate { get; set; }
        public string WFXArticleCode { get; set; }
        public string WFXArticleName { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string SizeCode { get; set; }
        public string SizeName { get; set; }
        public string FPPOOCNUm { get; set; }
        public string BuyerStyleRef { get; set; }
        public string RollNo { get; set; }
        public string RollBarcode { get; set; }
        public string ParentRollBarcode { get; set; }
        public string UOM { get; set; }
        public string RollOCRefNum { get; set; }
        public string Shade { get; set; }
        public string Location { get; set; }
        public string WareHouse { get; set; }
        public string InternalShade { get; set; }
        public decimal? GDIPendingUnits { get; set; }
        public decimal? RollUnits { get; set; }

    }

}
