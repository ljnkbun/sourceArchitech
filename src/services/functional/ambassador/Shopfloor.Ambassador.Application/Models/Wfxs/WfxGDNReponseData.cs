using Newtonsoft.Json;
using System.Globalization;

namespace Shopfloor.Ambassador.Application.Models.Wfxs
{
    public class WfxGDNReponseData
    {
        public int? ResponseID { get; set; }
        public string ErrorMsg { get; set; }
        public List<WfxGDNResponse> ResponseData { get; set; }
        public string Status { get; set; }
    }

    public class WfxGDNResponse
    {
        public string GDNNum { get; set; }
        public string GDNType { get; set; }
        public string OrderRefNum { get; set; }
        [JsonProperty("gDNCreationDate")]
        public string GDNCreationDate { get; set; }

        public DateTime? gDNCreationDate
        {
            get { return DateTime.Parse(GDNCreationDate, new CultureInfo("en-US")); }
        }
        public List<WfxGDNData> ListRoll { get; set; }
    }

    public class WfxGDNData
    {
        public string GDNNum { get; set; }
        public string GDNType { get; set; }
        public string OrderRefNum { get; set; }
        public DateTime? GDNCreationDate { get; set; }
        public string WFXArticleCode { get; set; }
        public string WFXArticleName { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string SizeCode { get; set; }
        public string SizeName { get; set; }
        public string FPPOOCNUm { get; set; }
        public string RollNo { get; set; }
        public string RollBarcode { get; set; }
        public decimal? RollUnits { get; set; }
        public string ParentRollBarcode { get; set; }
        public string UOM { get; set; }
        public string RollOCRefNum { get; set; }
        public string Shade { get; set; }
        public string Location { get; set; }
        public string WareHouse { get; set; }
        public string InternalShade { get; set; }
        public string GDINum { get; set; }

    }

}
