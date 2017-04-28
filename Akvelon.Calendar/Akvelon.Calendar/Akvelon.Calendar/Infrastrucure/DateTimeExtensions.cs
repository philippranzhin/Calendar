using System;

namespace Akvelon.Calendar.Infrastrucure
{
    public static class DateTimeExtensions
    {
        public static DateTime GetFirstDateOfWeek(this DateTime dayInWeek)
        {
            DayOfWeek firstDay = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(-1);

            return firstDayInWeek;
        }
        public static DateTime GetLastDateOfWeek(this DateTime dayInWeek)
        {
            DayOfWeek firstDay = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            DateTime lastDayInWeek = dayInWeek.Date;
            while (lastDayInWeek.DayOfWeek != firstDay)
                lastDayInWeek = lastDayInWeek.AddDays(1);

            return lastDayInWeek;
        }
    }
}
