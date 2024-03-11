namespace Shopfloor.IED.Application.Models.WeavingIEDs
{
    public class DataReportWeavingIEDModel
    {
        public VerticalRappo VerticalRappo { get; set; }

        public HorizontalRappo HorizontalRappo { get; set; }

        public HookGoBoard HookGoBoard { get; set; }

        public CottonDottingBoard CottonDottingBoard { get; set; }
    }

    public class HookGoBoard
    {
        public List<DataHookGoBoard> MarginHooks { get; set; }

        public List<RepeatHookGoBoard> BackgroundHooks { get; set; }
    }

    public class CottonDottingBoard
    {
        public List<DataCottonDottingBoard> GroupDataCottonDottingBoard { get; set; }
    }

    public class FilterGenerated
    {
        public int WeavingIEDId { get; set; }
        public int YarnId { get; set; }
        public string YarnCode { get; set; }
        public string YarnName { get; set; }
        public int SlotIndex { get; set; }
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
        public int LoopIndex { get; set; }
        public int WeavingRappoId { get; set; }
        public int ColumnNo { get; set; }
        public int PatternIndex { get; set; }
        public bool Type { get; set; }
        public int FilterPatternIndex { get; set; }
    }

    public class DataCottonDottingBoard
    {
        public int WeavingIEDId { get; set; }
        public int YarnId { get; set; }
        public string YarnCode { get; set; }
        public string YarnName { get; set; }
        public int RowIndex { get; set; }
        public List<int> DataPatternIndex { get; set; }
    }

    public class HorizontalRappo
    {
        public List<MarginBackgroundRappo> MarginHorizontalRappos { get; set; }
    }

    public class VerticalRappo
    {
        public List<MarginBackgroundRappo> MarginVerticleRappos { get; set; }

        public List<RepeatRappo> BackgroundVerticalRappos { get; set; }
    }

    public class MarginBackgroundRappo
    {
        public int WeavingIEDId { get; set; }
        public int YarnId { get; set; }
        public string YarnCode { get; set; }
        public string YarnName { get; set; }
        public int Quantity { get; set; }
    }

    public class RepeatRappo
    {
        public List<MarginBackgroundRappo> MarginBackgroundRappo { get; set; }
        public int Repeat { get; set; }
    }

    public class DataHookGoBoard
    {
        public int WeavingIEDId { get; set; }
        public int YarnId { get; set; }
        public string YarnCode { get; set; }
        public string YarnName { get; set; }
    }  
    
    public class RepeatHookGoBoard
    {
        public List<GroupHookGoBoard> GroupHookGoBoards { get; set; }
        public int Repeat { get; set; }
    }

    public class GroupHookGoBoard
    {
        public List<DataHookGoBoard> SplitHookGoBoard { get; set; }
    }
}