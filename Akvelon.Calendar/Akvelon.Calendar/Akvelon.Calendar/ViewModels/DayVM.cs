// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DayVM.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The day view model 
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
    using Akvelon.Calendar.Models;
    using Akvelon.Calendar.Models.Enums;

    /// <summary>
    ///     The day view model 
    /// </summary>
    public class DayVm : DateWithChildrenVm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DayVm"/> class.
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
        public DayVm(
            DateInfoModel dateInfo,
            IDateVmFactory factory,
            ReadOnlyObservableCollection<UserTaskModel> tasks)
            : base(dateInfo, factory, tasks)
        {
        }

        /// <summary>
        ///     The name.
        /// </summary>
        public override string Name => this.Date.Date.ToString("dddd MMM yy", CultureInfo.CurrentCulture);

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
                                && task.TaskDate.Day == this.Date.Date.Day));

                return new ReadOnlyObservableCollection<UserTaskModel>(result);
            }
        }

        /// <summary>
        ///     The next date.
        /// </summary>
        protected override DateInfoModel NextDate => new DateInfoModel(this.Date.Date.AddDays(+1), DateInfoType.Day);

        /// <summary>
        ///     The previous date.
        /// </summary>
        protected override DateInfoModel PreviousDate => new DateInfoModel(
            this.Date.Date.AddDays(-1),
            DateInfoType.Day);

        /// <summary>
        ///     The children filling.
        /// </summary>
        protected override void ChildrenFilling()
        {
            DateTime currentDate = new DateTime(this.Date.Date.Year, this.Date.Date.Month, this.Date.Date.Day, 1, 0, 0);
            for (int i = 1; i <= DateTimeExtensions.HoursInDay; i++)
            {
                this.RegisterChild(new DateInfoModel(currentDate, DateInfoType.Hour));
                currentDate = currentDate.AddHours(1);
            }
        }
    }
}