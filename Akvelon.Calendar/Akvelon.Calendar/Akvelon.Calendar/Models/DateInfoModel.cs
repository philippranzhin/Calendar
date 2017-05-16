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

    using Akvelon.Calendar.Models.Enums;

    /// <summary>
    ///     The date info model. Is a base model for each Date view model in current application.
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
        public DateInfoModel(DateTime date, DateRepresentationType dateType)
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
        public DateRepresentationType DateType { get; }
    }
}