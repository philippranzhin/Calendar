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
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;

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
        public override string Name => this.DateInfo.Date.ToString("h tt", CultureInfo.CurrentCulture);

        /// <summary>
        ///     The next date.
        /// </summary>
        public override DateInfoModel NextDate => new DateInfoModel(this.DateInfo.Date.AddHours(+1), DateRepresentationType.Hour);

        /// <summary>
        ///     The previous date.
        /// </summary>
        public override DateInfoModel PreviousDate => new DateInfoModel(
            this.DateInfo.Date.AddHours(-1),
            DateRepresentationType.Hour);

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
                   && this.DateInfo.Date.Day == date.Day && this.DateInfo.Date.Hour == date.Hour;
        }

        /// <summary>
        /// A method that is called only once when the children property is called the first time. 
        /// The parent class expects children to use the RegisterChild method in this method for each of their own children
        /// </summary>
        protected override void FillChildren()
        {
            throw new NotImplementedException("In current case class HourVm not provides an ability to have children");
        }
    }
}