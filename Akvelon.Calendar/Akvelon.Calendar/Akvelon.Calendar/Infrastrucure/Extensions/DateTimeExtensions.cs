// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeExtensions.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The date time extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Infrastrucure.Extensions
{
    using System;
    using System.Threading;

    /// <summary>
    ///     The date time extensions. Extenes the DateTime structure, adds in it some constants and ability to get first/last day of week in current culture.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        ///     The count of hours in day.
        /// </summary>
        public const int HoursInDay = 24;

        /// <summary>
        ///     The count of months in year.
        /// </summary>
        public const int MonthsInYear = 12;

        /// <summary>
        ///     The count of weeksize.
        /// </summary>
        public const int Weeksize = 7;

        /// <summary>
        /// The get first date of week.
        /// </summary>
        /// <param name="dayInWeek">
        /// The day in week.
        /// </param>
        /// <returns>
        /// The <see cref="DateTime"/>.
        /// Return DateTime, which is a first day of week in current culture.
        /// </returns>
        public static DateTime GetFirstDateOfWeek(this DateTime dayInWeek)
        {
            DateTime firstDayInWeek = dayInWeek.Date;
            while (!firstDayInWeek.IsFirstDayOfWeek())
            {
                firstDayInWeek = firstDayInWeek.AddDays(-1);
            }

            return firstDayInWeek;
        }

        /// <summary>
        /// The get last date of week.
        /// </summary>
        /// <param name="dayInWeek">
        /// The day in week.
        /// </param>
        /// <returns>
        /// The <see cref="DateTime"/>.
        /// Return DateTime, which is a last day of week in current culture.
        /// </returns>
        public static DateTime GetLastDateOfWeek(this DateTime dayInWeek)
        {
            return GetFirstDateOfWeek(dayInWeek).AddDays(Weeksize - 1);
        }

        /// <summary>
        /// The is first.
        /// </summary>
        /// <param name="date">
        /// The date.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// Return true if current DateTime.Day is a first day of week in current culture.
        /// </returns>
        public static bool IsFirstDayOfWeek(this DateTime date)
        {
            return date.DayOfWeek == Thread.CurrentThread.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
        }
    }
}