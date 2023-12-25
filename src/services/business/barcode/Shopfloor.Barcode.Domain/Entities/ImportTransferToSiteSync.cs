using Shopfloor.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopfloor.Barcode.Domain.Entities
{
    public class ImportTransferToSiteSync : BaseEntity
    {
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal? Qty { get; set; }
        public string UOM { get; set; }
        public string StoringUOM { get; set; }
        public string GDNNo { get; set; }
        public string FromSite { get; set; }
        public string ToSite { get; set; }
        public string OC { get; set; }
        public string LotNo { get; set; }
    }
}
