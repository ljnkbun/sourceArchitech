using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.RequestDivisionFiles
{
    public class RequestDivisionFileParameter : RequestParameter
    {
        public int? RequestDivisionId { get; set; }
        public FileType? FileType { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
    }
}
