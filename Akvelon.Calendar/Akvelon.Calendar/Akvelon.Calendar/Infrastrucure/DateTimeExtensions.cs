using System;

namespace Akvelon.Calendar.Infrastrucure
{
    public static class DateTimeExtensions
    {
        public const int WEEKSIZE = 7;
        public const int MONTHS_IN_YEAR = 12;
        public const int HOURS_IN_DAY= 24;

        public static DateTime GetFirstDateOfWeek(this DateTime dayInWeek)
        {
            DateTime firstDayInWeek = dayInWeek.Date;
            while (!firstDayInWeek.IsFirst())
                firstDayInWeek = firstDayInWeek.AddDays(-1);

            return firstDayInWeek;
        }

        public static DateTime GetLastDateOfWeek(this DateTime dayInWeek)
        {
           return GetFirstDateOfWeek(dayInWeek).AddDays(WEEKSIZE-1);
        }

        public static bool IsFirst(this DateTime date)
        {
           return date.DayOfWeek == System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
        }
    }
}
