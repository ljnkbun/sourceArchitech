namespace Shopfloor.EventBus.Models.Message
{
    public class UpdateActualQuanlityForStripMessage
    {
        public int FPPOId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime Date { get; set; }
        public UpdateActualQuanlityForStripMessage(int fppoId, decimal quantity, DateTime date)
        {
            FPPOId = fppoId;
            Quantity = quantity;
            Date = date;
        }
    }

}
