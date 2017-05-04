using System;
using Akvelon.Calendar.Infrastrucure;

namespace Akvelon.Calendar.Models
{
    public class DateInfoModel
    {
        public DateTime Date { get; }
        public DateInfoType DateType { get; }

        public DateInfoModel(DateTime date, DateInfoType dateType)
        {
            Date = date;
            DateType = dateType;
        }

        public bool Compare(DateInfoModel dateInfo)
        {
            return dateInfo.DateType == DateType && Compare(dateInfo.Date);
        }

        public bool Compare(DateTime date)
        {
            switch (DateType)
            {
                case DateInfoType.Year:
                {
                    return Date.Year == date.Year;
                }
                case DateInfoType.Month:
                {
                    return Date.Year == date.Year && Date.Month == date.Month;
                }
                case DateInfoType.Week:
                {
                    return
                        Date.Year == date.Year &&
                        Date.Month == date.Month &&
                        Date.Date.GetFirstDateOfWeek() <= date &&
                        Date.Date.GetLastDateOfWeek() >= date;
                }
                case DateInfoType.Day:
                {
                    return
                        Date.Year == date.Year &&
                        Date.Month == date.Month &&
                        Date.Day == date.Day;
                }
                case DateInfoType.Hour:
                {
                    return
                        Date.Year == date.Year &&
                        Date.Month == date.Month &&
                        Date.Day == date.Day &&
                        Date.Hour == date.Hour;
                }

                default:
                {
                    return false;
                }
            }
        }
    }
}
