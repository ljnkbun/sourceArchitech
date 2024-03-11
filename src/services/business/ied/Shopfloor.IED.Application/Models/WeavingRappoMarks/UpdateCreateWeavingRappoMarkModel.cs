namespace Shopfloor.IED.Application.Models.WeavingRappoMarks
{
    public class UpdateCreateWeavingRappoMarkModel
    {
        public int Id { get; set; }
        public int WeavingRappoId { get; set; }
        public int ColumnNo { get; set; }
        public int PatternIndex { get; set; }
        public bool Type { get; set; }
    }
}