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
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;

    using Akvelon.Calendar.Infrastrucure.DateVmBase;
    using Akvelon.Calendar.Infrastrucure.Extensions;
    using Akvelon.Calendar.Models;
    using Akvelon.Calendar.Models.Enums;

    /// <summary>
    ///     The month view model 
    /// </summary>
    public class MonthVm : DateWithChildrenVm
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
        /// <param name="tasks">
        /// The tasks.
        /// </param>
        public MonthVm(
            DateInfoModel dateInfo,
            IDateVmFactory factory,
            ReadOnlyObservableCollection<UserTaskModel> tasks)
            : base(dateInfo, factory, tasks)
        {
        }

        /// <summary>
        ///     The name.
        /// </summary>
        public override string Name => this.Date.Date.ToString("MMMM yyyy", CultureInfo.CurrentCulture);

        /// <summary>
        ///     Gets the user tasks.
        /// </summary>
        public override ReadOnlyObservableCollection<UserTaskModel> UserTasks
        {
            get
            {
                ObservableCollection<UserTaskModel> result = new ObservableCollection<UserTaskModel>(
                    this.Tasks.Where(
                        task => task.TaskDate.Year == this.Date.Date.Year
                                && task.TaskDate.Month == this.Date.Date.Month));

                return new ReadOnlyObservableCollection<UserTaskModel>(result);
            }
        }

        /// <summary>
        ///     The next date.
        /// </summary>
        protected override DateInfoModel NextDate => new DateInfoModel(
            this.Date.Date.AddMonths(+1),
            DateInfoType.Month);

        /// <summary>
        ///     The previous date.
        /// </summary>
        protected override DateInfoModel PreviousDate => new DateInfoModel(
            this.Date.Date.AddMonths(-1),
            DateInfoType.Month);

        /// <summary>
        ///     The children filling.
        /// </summary>
        protected override void ChildrenFilling()
        {
            DateTime currentDate = new DateTime(this.Date.Date.Year, this.Date.Date.Month, 1);
            this.RegisterChild(new DateInfoModel(currentDate, DateInfoType.Week));
            currentDate = currentDate.AddDays(1);

            while (!(currentDate.Month != this.Date.Date.Month && currentDate.IsFirstDayOfWeek()))
            {
                if (currentDate.IsFirstDayOfWeek())
                {
                    this.RegisterChild(new DateInfoModel(currentDate, DateInfoType.Week));
                }

                currentDate = currentDate.AddDays(1);
            }
        }
    }
}