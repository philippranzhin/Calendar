// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateInfoModel.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The date info model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Models
{
    using System;

    using Akvelon.Calendar.Infrastrucure.Extensions;
    using Akvelon.Calendar.Models.Enums;

    /// <summary>
    ///     The date info model. Is a base model for each DateVm in current application.
    /// </summary>
    public class DateInfoModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateInfoModel"/> class.
        /// </summary>
        /// <param name="date">
        /// The date.
        /// </param>
        /// <param name="dateType">
        /// The date type.
        /// </param>
        public DateInfoModel(DateTime date, DateInfoType dateType)
        {
            this.Date = date;
            this.DateType = dateType;
        }

        /// <summary>
        ///     Gets the date.
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        ///     Gets the date type.
        /// </summary>
        public DateInfoType DateType { get; }

        /// <summary>
        /// The compare.
        /// </summary>
        /// <param name="dateInfo">
        /// The date info.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Compare(DateInfoModel dateInfo)
        {
            return dateInfo.DateType == this.DateType && this.Compare(dateInfo.Date);
        }

        /// <summary>
        /// The compare.
        /// </summary>
        /// <param name="date">
        /// The date.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Compare(DateTime date)
        {
            switch (this.DateType)
            {
                case DateInfoType.Year:
                    {
                        return this.Date.Year == date.Year;
                    }

                case DateInfoType.Month:
                    {
                        return this.Date.Year == date.Year && this.Date.Month == date.Month;
                    }

                case DateInfoType.Week:
                    {
                        return this.Date.Year == date.Year && this.Date.Month == date.Month
                               && this.Date.Date.GetFirstDateOfWeek() <= date
                               && this.Date.Date.GetLastDateOfWeek() >= date;
                    }

                case DateInfoType.Day:
                    {
                        return this.Date.Year == date.Year && this.Date.Month == date.Month
                               && this.Date.Day == date.Day;
                    }

                case DateInfoType.Hour:
                    {
                        return this.Date.Year == date.Year && this.Date.Month == date.Month && this.Date.Day == date.Day
                               && this.Date.Hour == date.Hour;
                    }

                default:
                    {
                        return false;
                    }
            }
        }
    }
}