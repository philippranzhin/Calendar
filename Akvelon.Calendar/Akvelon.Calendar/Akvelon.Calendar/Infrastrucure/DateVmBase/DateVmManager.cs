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

    using Akvelon.Calendar.Infrastrucure.UserTasks;
    using Akvelon.Calendar.Models;
    using Akvelon.Calendar.Models.Enums;
    using Akvelon.Calendar.ViewModels;

    using Database.DataBase.Models;

    /// <summary>
    /// Date model dispatcher. Describes objects that can manage the DateVm collection, 
    /// provide an interface for creating DateVm, 
    /// ensure that all DateVm in the collection must have a common link to the collection of tasks.
    /// </summary>
    public class DateVmManager : IDateVmFactory
    {
        /// <summary>
        /// The cache size.
        /// </summary>
        private const int CacheSize = 30;

        /// <summary>
        ///     The date view model collection.
        /// </summary>
        private readonly List<DateVm> dateVmCollection = new List<DateVm>();

        /// <summary>
        ///     The tasks.
        /// </summary>
        private readonly ReadOnlyObservableCollection<UserTaskModel> tasks;

        /// <summary>
        /// The task mediator.
        /// </summary>
        private readonly IUserTaskMediator taskMediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="DateVmManager"/> class.
        /// </summary>
        /// <param name="taskMediator">
        /// The task mediator.
        /// </param>
        public DateVmManager(IUserTaskMediator taskMediator)
        {
            this.taskMediator = taskMediator;
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
            DateVm result = this.dateVmCollection.FirstOrDefault(dateVm => dateVm.IsDateEqual(dateInfo));

            if (this.dateVmCollection.Count > CacheSize)
            {
                this.dateVmCollection.RemoveRange(0, this.dateVmCollection.Count - CacheSize);
            }

            if (result != null)
            {                
                return result;
            }

            switch (dateInfo.DateType)
            {
                case DateRepresentationType.Year:
                    {
                        result = new YearVm(dateInfo, this, this.taskMediator);
                        break;
                    }

                case DateRepresentationType.Month:
                    {
                        result = new MonthVm(dateInfo, this, this.taskMediator);
                        break;
                    }

                case DateRepresentationType.Week:
                    {
                        result = new WeekVm(dateInfo, this, this.taskMediator);
                        break;
                    }

                case DateRepresentationType.Day:
                    {
                        result = new DayVm(dateInfo, this, this.taskMediator);
                        break;
                    }

                case DateRepresentationType.Hour:
                    {
                        result = new HourVm(dateInfo, this, this.taskMediator);
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
        /// <param name="mediator">
        /// The task mediator.
        /// </param>
        /// <returns>
        /// The <see cref="DateVm"/>.
        /// </returns>
        public DateVm Create(DateInfoModel dateInfo, IDateVmFactory factory, IUserTaskMediator mediator)
        {
            return this.GetOrCreate(dateInfo);
        }
    }
}