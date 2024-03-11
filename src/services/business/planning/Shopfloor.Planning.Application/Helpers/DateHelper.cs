using System.Globalization;

namespace Shopfloor.Planning.Application.Helpers
{
    public static class DateHelper
    {
        public static int? GetWeekNumber(DateTime? date)
        {
            if (date.HasValue)
            {
                Calendar calendar = CultureInfo.CurrentCulture.Calendar;
                return calendar.GetWeekOfYear(date.Value, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            }
            return null;
        }

        public static int? GetMonthNumber(DateTime? date)
        {
            return date?.Month;
        }
    }
}
