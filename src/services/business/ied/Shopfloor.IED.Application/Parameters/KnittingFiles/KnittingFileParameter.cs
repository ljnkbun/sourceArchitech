using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.KnittingFiles
{
    public class KnittingFileParameter : RequestParameter
    {
        public int? KnittingIEDId { get; set; }
        public FileType? FileType { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
    }
}
