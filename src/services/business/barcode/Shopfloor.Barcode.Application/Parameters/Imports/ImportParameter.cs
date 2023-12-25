using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Barcode.Application.Parameters.Imports
{
    public class ImportParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public ImportStatus? Status { get; set; }
        public ImportType? Type { get; set; }

    }
}
