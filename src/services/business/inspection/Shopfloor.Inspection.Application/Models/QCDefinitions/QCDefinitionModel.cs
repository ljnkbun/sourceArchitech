using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Application.Models.AQLVersions;
using Shopfloor.Inspection.Application.Models.Conversions;
using Shopfloor.Inspection.Application.Models.FourPointsSystems;
using Shopfloor.Inspection.Application.Models.OneHundredPointSystems;
using Shopfloor.Inspection.Application.Models.QCDefinitionDefects;
using Shopfloor.Inspection.Application.Models.QCTypes;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.Models.QCDefinitions
{
    public class QCDefinitionModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Buyer { get; set; }
        public string Category { get; set; }
        public decimal? AcceptanceValue { get; set; }
        public int? ConversionId { get; set; }
        public int? QCTypeId { get; set; }
        public ConversionModel Conversion { get; set; }
        public virtual ICollection<QCDefinitionDefectModel> QCDefinitionDefects { get; set; }
        public decimal? PercentQC { get; set; }
        public decimal? PercentAcceptance { get; set; }
        public decimal? FixedQty { get; set; }
        public decimal? AcceptanceQty { get; set; }
        public decimal? Quantity { get; set; }
        public int? AQLVersionId { get; set; }
        public int? FourPointsSystemId { get; set; }
        public int? OneHundredPointSystemId { get; set; }
        public AQLVersionModel AQLVersion { get; set; }
        public QCTypeModel QCType { get; set; }
        public FourPointsSystemModel FourPointsSystem { get; set; }
        public OneHundredPointSystemModel OneHundredPointSystem { get; set; }
    }
}
