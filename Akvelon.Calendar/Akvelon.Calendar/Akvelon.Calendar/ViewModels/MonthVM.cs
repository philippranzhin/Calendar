// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MonthVM.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The month view model 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.ViewModels
{
    using System;
    using System.Globalization;

    using Akvelon.Calendar.Infrastrucure.DateVmBase;
    using Akvelon.Calendar.Infrastrucure.Extensions;
    using Akvelon.Calendar.Infrastrucure.UserTasks;
    using Akvelon.Calendar.Models;
    using Akvelon.Calendar.Models.Enums;

    /// <summary>
    ///     The month view model 
    /// </summary>
    public class MonthVm : DateVm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MonthVm"/> class.
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
        public MonthVm(
            DateInfoModel dateInfo,
            IDateVmFactory factory,
            IUserTaskMediator taskMediator)
            : base(dateInfo, factory, taskMediator)
        {
        }

        /// <summary>
        ///     The name.
        /// </summary>
        public override string Name => this.DateInfo.Date.ToString("MMMM yyyy", CultureInfo.CurrentCulture);
        
        /// <summary>
        ///     The next date.
        /// </summary>
        public override DateInfoModel NextDate => new DateInfoModel(
            this.DateInfo.Date.AddMonths(+1),
            DateRepresentationType.Month);

        /// <summary>
        ///     The previous date.
        /// </summary>
        public override DateInfoModel PreviousDate => new DateInfoModel(
            this.DateInfo.Date.AddMonths(-1),
            DateRepresentationType.Month);

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
            return this.DateInfo.Date.Year == date.Year && this.DateInfo.Date.Month == date.Month;
        }

        /// <summary>
        /// A method that is called only once when the children property is called the first time. 
        /// The parent class expects children to use the RegisterChild method in this method for each of their own children
        /// </summary>
        protected override void FillChildren()
        {
            DateTime currentDate = new DateTime(this.DateInfo.Date.Year, this.DateInfo.Date.Month, 1);
            this.RegisterChild(new DateInfoModel(currentDate, DateRepresentationType.Week));
            currentDate = currentDate.AddDays(1);

            while (!(currentDate.Month != this.DateInfo.Date.Month && currentDate.IsFirstDayOfWeek()))
            {
                if (currentDate.IsFirstDayOfWeek())
                {
                    this.RegisterChild(new DateInfoModel(currentDate, DateRepresentationType.Week));
                }

                currentDate = currentDate.AddDays(1);
            }
        }
    }
}