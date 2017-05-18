// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeekVM.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The week view model 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;

    using Akvelon.Calendar.Infrastrucure.DateVmBase;
    using Akvelon.Calendar.Infrastrucure.Extensions;
    using Akvelon.Calendar.Infrastrucure.UserTasks;
    using Akvelon.Calendar.Models;
    using Akvelon.Calendar.Models.Enums;

    /// <summary>
    ///     The week view model 
    /// </summary>
    public class WeekVm : DateVm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeekVm"/> class.
        /// </summary>
        /// <param name="dateInfo">
        /// The date info.
        /// </param>
        /// <param name="factory">
        /// The factory.
        /// </param>
        /// <param name="taskMediator">
        /// The task mediator.
        /// </param>
        public WeekVm(
            DateInfoModel dateInfo,
            IDateVmFactory factory,
            IUserTaskMediator taskMediator)
            : base(dateInfo, factory, taskMediator)
        {
        }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        public override string Name
        {
            get
            {
                string result = string.Empty;
                result += this.Children.First().DateInfo.Date.ToString("dd MMM", CultureInfo.CurrentCulture);
                result += " - ";
                result += this.Children.Last().DateInfo.Date.ToString("dd MMM", CultureInfo.CurrentCulture);
                return result;
            }
        }



        /// <summary>
        ///     The next date.
        /// </summary>
        public override DateInfoModel NextDate => new DateInfoModel(
            this.DateInfo.Date.AddDays(DateTimeExtensions.Weeksize),
            DateRepresentationType.Week);

        /// <summary>
        ///     The previous date.
        /// </summary>
        public override DateInfoModel PreviousDate => new DateInfoModel(
            this.DateInfo.Date.AddDays(-DateTimeExtensions.Weeksize),
            DateRepresentationType.Week);

        /// <summary>
        /// The is date equal. Returns "true" if the Date property of current instance is equal to the date parameter
        /// </summary>
        /// <param name="date">
        /// The date.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool IsDateEqual(DateTime date)
        {
            return this.DateInfo.Date.Year == date.Year && this.DateInfo.Date.Month == date.Month
                   && this.DateInfo.Date.GetFirstDateOfWeek() <= date
                   && this.DateInfo.Date.GetLastDateOfWeek() >= date;
        }

        /// <summary>
        /// A method that is called only once when the children property is called the first time. 
        /// The parent class expects children to use the RegisterChild method in this method for each of their own children
        /// </summary>
        protected override void FillChildren()
        {
            DateTime currentDate = this.DateInfo.Date.GetFirstDateOfWeek();

            this.RegisterChild(new DateInfoModel(currentDate, DateRepresentationType.Day));
            currentDate = currentDate.AddDays(1);
            while (!currentDate.IsFirstDayOfWeek())
            {
                this.RegisterChild(new DateInfoModel(currentDate, DateRepresentationType.Day));
                currentDate = currentDate.AddDays(1);
            }
        }
    }
}