using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Barcode.Application.Parameters.AppVersions
{
    public class AppVersionParameter : RequestParameter
    {
        public int? FileId { get; set; }
        public int? Version { get; set; }
        public string Name { get; set; }
    }
}