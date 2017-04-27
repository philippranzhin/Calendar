using System;

namespace Akvelon.Calendar.Infrastrucure
{
    public class DateInfo
    {
        public DateTime Date { get; }
        public DateInfoType DateType { get; }

        public DateInfo(DateTime date, DateInfoType dateType)
        {
            Date = date;
            DateType = dateType;
        }
    }

    public enum DateInfoType
    {
        Year,
        Month,
        Week,
        Day
    }
}
