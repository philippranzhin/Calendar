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

    using Akvelon.Calendar.Infrastrucure.Extensions;
    using Akvelon.Calendar.Infrastrucure.DateVmBase;
    using Akvelon.Calendar.Models;
    using Akvelon.Calendar.Models.Enums;

    /// <summary>
    ///     The week view model 
    /// </summary>
    public class WeekVm : DateWithChildrenVm
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
        /// <param name="tasks">
        /// The tasks.
        /// </param>
        public WeekVm(
            DateInfoModel dateInfo,
            IDateVmFactory factory,
            ReadOnlyObservableCollection<UserTaskModel> tasks)
            : base(dateInfo, factory, tasks)
        {
        }

        /// <summary>
        ///     Gets the day row.
        /// </summary>
        public string DayRow
        {
            get
            {
                string row = string.Empty;
                this.Children.ToList().ForEach(day => row += $"{day.DateInfo.Date.Day}\t");
                return row;
            }
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
        ///     Gets the user tasks.
        /// </summary>
        public override ReadOnlyObservableCollection<UserTaskModel> UserTasks
        {
            get
            {
                ObservableCollection<UserTaskModel> result = new ObservableCollection<UserTaskModel>(
                    this.Tasks.Where(
                        task => task.TaskDate.Year == this.Date.Date.Year && task.TaskDate.Month == this.Date.Date.Month
                                && task.TaskDate >= this.Date.Date.GetFirstDateOfWeek()
                                && task.TaskDate <= this.Date.Date.GetLastDateOfWeek()));

                return new ReadOnlyObservableCollection<UserTaskModel>(result);
            }
        }

        /// <summary>
        ///     The next date.
        /// </summary>
        protected override DateInfoModel NextDate => new DateInfoModel(
            this.Date.Date.AddDays(DateTimeExtensions.Weeksize),
            DateInfoType.Week);

        /// <summary>
        ///     The previous date.
        /// </summary>
        protected override DateInfoModel PreviousDate => new DateInfoModel(
            this.Date.Date.AddDays(-DateTimeExtensions.Weeksize),
            DateInfoType.Week);

        /// <summary>
        ///     The children filling.
        /// </summary>
        protected override void ChildrenFilling()
        {
            DateTime currentDate = this.Date.Date.GetFirstDateOfWeek();

            this.RegisterChild(new DateInfoModel(currentDate, DateInfoType.Day));
            currentDate = currentDate.AddDays(1);
            while (!currentDate.IsFirstDayOfWeek())
            {
                this.RegisterChild(new DateInfoModel(currentDate, DateInfoType.Day));
                currentDate = currentDate.AddDays(1);
            }
        }
    }
}