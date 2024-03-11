using Shopfloor.EventBus.Definations;

namespace Shopfloor.EventBus.Models.Message
{
    public class UpdateStatusExportsMessage
    {
        public int[] ExportIds { get; set; }
        public NoteStatus? Status { get; set; }

        public UpdateStatusExportsMessage(int[] exportIds, NoteStatus? status)
        {
            ExportIds = exportIds;
            Status = status;
        }
    }

}
