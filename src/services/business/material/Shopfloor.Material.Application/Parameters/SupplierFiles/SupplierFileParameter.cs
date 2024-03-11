using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Material.Application.Parameters.SupplierFiles
{
    public class SupplierFileParameter : RequestParameter
    {
        public int? SupplierId { get; set; }

        public FileType? FileType { get; set; }

        public string FileName { get; set; }

        public string Description { get; set; }

        public string FileId { get; set; }
    }
}