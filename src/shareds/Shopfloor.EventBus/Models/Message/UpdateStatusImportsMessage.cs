using Shopfloor.EventBus.Definations;

namespace Shopfloor.EventBus.Models.Message
{
    public class UpdateStatusImportsMessage
    {
        public int[] ImportIds { get; set; }
        public NoteStatus? Status { get; set; }

        public UpdateStatusImportsMessage(int[] importIds, NoteStatus? status)
        {
            ImportIds = importIds;
            Status = status;
        }
    }

}
