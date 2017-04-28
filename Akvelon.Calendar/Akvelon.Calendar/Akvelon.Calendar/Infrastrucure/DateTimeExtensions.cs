using System;

namespace Akvelon.Calendar.Infrastrucure
{
    public static class DateTimeExtensions
    {
        public const int WEEKSIZE = 7;
        public static DateTime GetFirstDateOfWeek(this DateTime dayInWeek)
        {
            return GetDateOfWeek(dayInWeek);
        }

        public static DateTime GetLastDateOfWeek(this DateTime dayInWeek)
        {
            return GetDateOfWeek(dayInWeek,false);
        }

        private static DateTime GetDateOfWeek(DateTime dayInWeek,bool isFirst = true)
        {
            DayOfWeek firstDay = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(isFirst?1:-1);

            return firstDayInWeek;
        }
    }
}
