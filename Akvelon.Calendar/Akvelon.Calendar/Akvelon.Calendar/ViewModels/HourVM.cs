// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HourVM.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The hour view model 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;

    using Akvelon.Calendar.Infrastrucure.DateVmBase;
    using Akvelon.Calendar.Models;
    using Akvelon.Calendar.Models.Enums;

    /// <summary>
    ///     The hour view model 
    /// </summary>
    internal class HourVm : DateVm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HourVm"/> class.
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
        public HourVm(
            DateInfoModel dateInfo,
            IDateVmFactory factory,
            ReadOnlyObservableCollection<UserTaskModel> tasks)
            : base(dateInfo, factory, tasks)
        {
        }

        /// <summary>
        ///     The name.
        /// </summary>
        public override string Name => this.Date.Date.ToString("h tt", CultureInfo.CurrentCulture);

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
                                && task.TaskDate.Day == this.Date.Date.Day
                                && task.TaskDate.Hour == this.Date.Date.Hour));

                return new ReadOnlyObservableCollection<UserTaskModel>(result);
            }
        }

        /// <summary>
        ///     The next date.
        /// </summary>
        protected override DateInfoModel NextDate => new DateInfoModel(this.Date.Date.AddHours(+1), DateInfoType.Hour);

        /// <summary>
        ///     The previous date.
        /// </summary>
        protected override DateInfoModel PreviousDate => new DateInfoModel(
            this.Date.Date.AddHours(-1),
            DateInfoType.Hour);
    }
}