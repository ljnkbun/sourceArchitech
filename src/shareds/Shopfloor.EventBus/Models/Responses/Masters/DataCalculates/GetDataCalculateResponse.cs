namespace Shopfloor.EventBus.Models.Responses
{
    public class GetDataCalculateResponse
    {
        public MachineDto Machine { get; set; }
        public LineDto Line { get; set; }
        public List<CalendarDetailDto> CalendarDetails { get; set; }
    }

    public class MachineDto
    {
        public string SerialNo { get; set; }
        public string Remarks { get; set; }
        public decimal? Capacity { get; set; }
        public int? FactoryId { get; set; }
        public int? ProcessId { get; set; }
        public string Gauge { get; set; }
        public string MachineDiameter { get; set; }
    }

    public class LineDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Worker { get; set; }
        public int? WFXLineId { get; set; }
        public int? FactoryId { get; set; }
        public int? ProcessId { get; set; }
    }

    public class CalendarDetailDto
    {
        public int CalendarId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal WorkingHours { get; set; }
        public decimal BreakHours { get; set; }
    }
}
