using System;

namespace Akvelon.Calendar.Infrastrucure
{
    public class DateInfo
    {
        public DateTime Date { get; }
        public Enums.DateInfoType DateType { get; }

        public DateInfo(DateTime date, Enums.DateInfoType dateType)
        {
            Date = date;
            DateType = dateType;
        }
    }
}
