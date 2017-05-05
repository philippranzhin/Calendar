// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateVmManager.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The date view model manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Infrastrucure.DateVmBase
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using Akvelon.Calendar.Models;
    using Akvelon.Calendar.Models.Enums;
    using Akvelon.Calendar.ViewModels;

    /// <summary>
    /// Date model dispatcher. Describes objects that can manage the DateVm collection, 
    /// provide an interface for creating DateVm, 
    /// ensure that all DateVm in the collection must have a common link to the collection of tasks.
    /// </summary>
    public class DateVmManager : IDateVmFactory
    {
        /// <summary>
        ///     The date view model collection.
        /// </summary>
        private readonly List<DateVm> dateVmCollection = new List<DateVm>();

        /// <summary>
        ///     The tasks.
        /// </summary>
        private readonly ReadOnlyObservableCollection<UserTaskModel> tasks;

        /// <summary>
        /// Initializes a new instance of the <see cref="DateVmManager"/> class.
        /// </summary>
        /// <param name="tasks">
        /// The tasks.
        /// </param>
        public DateVmManager(ReadOnlyObservableCollection<UserTaskModel> tasks)
        {
            this.tasks = tasks;
        }

        /// <summary>
        /// The get or create.
        /// </summary>
        /// <param name="dateInfo">
        /// The date info.
        /// </param>
        /// <returns>
        /// The <see cref="DateVm"/>.
        /// </returns>
        public DateVm GetOrCreate(DateInfoModel dateInfo)
        {
            DateVm result = this.dateVmCollection.FirstOrDefault(dateVm => dateInfo.Compare(dateVm.DateInfo));

            if (result != null)
            {
                return result;
            }

            switch (dateInfo.DateType)
            {
                case DateInfoType.Year:
                    {
                        result = new YearVm(dateInfo, this, this.tasks);
                        break;
                    }

                case DateInfoType.Month:
                    {
                        result = new MonthVm(dateInfo, this, this.tasks);
                        break;
                    }

                case DateInfoType.Week:
                    {
                        result = new WeekVm(dateInfo, this, this.tasks);
                        break;
                    }

                case DateInfoType.Day:
                    {
                        result = new DayVm(dateInfo, this, this.tasks);
                        break;
                    }

                case DateInfoType.Hour:
                    {
                        result = new HourVm(dateInfo, this, this.tasks);
                        break;
                    }

                default:
                    {
                        return null;
                    }
            }

            this.dateVmCollection.Add(result);
            return result;
        }

        /// <summary>
        /// The create.
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
        /// <returns>
        /// The <see cref="DateVm"/>.
        /// </returns>
        public DateVm Create(DateInfoModel dateInfo, IDateVmFactory factory, ReadOnlyObservableCollection<UserTaskModel> tasks)
        {
            return this.GetOrCreate(dateInfo);
        }
    }
}