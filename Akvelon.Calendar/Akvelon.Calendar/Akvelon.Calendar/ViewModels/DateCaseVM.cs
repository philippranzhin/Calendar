// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateCaseVm.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The date case view model 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Linq;

    using Akvelon.Calendar.Infrastrucure.DateVmBase;
    using Akvelon.Calendar.Infrastrucure.UserTasks;

    /// <summary>
    ///   The date case view model. Provides a collection of DateVm, selected DateVm, notification on new DateCase need.
    /// </summary>
    public class DateCaseVm : MvvmBase
    {
        /// <summary>
        ///     The old dates count.
        /// </summary>
        private const uint OldDatesCount = 10;

        /// <summary>
        ///     The task Mediator.
        /// </summary>
        private readonly UserTaskMediator taskMediator;

        /// <summary>
        ///     The current date view model 
        /// </summary>
        private DateVm currentDateVm;

        /// <summary>
        /// Initializes a new instance of the <see cref="DateCaseVm"/> class.
        /// </summary>
        /// <param name="currentDateVm">
        /// The current date view model 
        /// </param>
        /// <param name="userTaskMediator">
        /// The user task mediator.
        /// </param>
        public DateCaseVm(DateVm currentDateVm, UserTaskMediator userTaskMediator)
        {
            this.taskMediator = userTaskMediator;
            this.CurrentDateVm = currentDateVm;
            this.DateVmCollection = new ObservableCollection<DateVm>();

            this.SetCurrentVm();
            this.GenerateDates();
        }

        /// <summary>
        ///     The new view model needed.
        /// </summary>
        public event DateVmHandler NewVmNeeded;

        /// <summary>
        ///     Gets or sets the current date view model 
        /// </summary>
        public DateVm CurrentDateVm
        {
            get
            {
                return this.currentDateVm;
            }

            set
            {
                this.currentDateVm = value;
                this.OnPropertyChanged("CurrentDateVM");

                if (this.DateVmCollection != null && this.DateVmCollection.Last() == this.CurrentDateVm)
                {
                    this.AddDateVm(this.DateVmCollection.Last().GetNext());
                }

                if (this.DateVmCollection != null && this.DateVmCollection.First() == this.CurrentDateVm)
                {
                    this.GenerateDates();
                }
            }
        }

        /// <summary>
        ///     Gets the date view model collection.
        /// </summary>
        public ObservableCollection<DateVm> DateVmCollection { get; }

        /// <summary>
        /// The on new view model  needed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="newDateVm">
        /// The new date view model 
        /// </param>
        protected virtual void OnNewWmNeeded(IDateVm sender, DateVm newDateVm)
        {
            this.NewVmNeeded?.Invoke(sender, newDateVm);
        }

        /// <summary>
        /// The add date view model 
        /// </summary>
        /// <param name="dateVm">
        /// The date view model 
        /// </param>
        private void AddDateVm(DateVm dateVm)
        {
            this.DateVmCollection.Add(dateVm);
            this.taskMediator.AddClient(dateVm);
            dateVm.NewVmNeeded += this.OnNewWmNeeded;
        }

        /// <summary>
        ///     The generate dates.
        /// </summary>
        private void GenerateDates()
        {
            if (this.DateVmCollection == null || this.DateVmCollection.Count == 0)
            {
                return;
            }

            for (int i = 0; i < OldDatesCount; i++)
            {
                this.AddDateVm(this.DateVmCollection.First().GetPrevious());
                this.DateVmCollection.Move(this.DateVmCollection.Count - 1, 0);
            }
        }

        /// <summary>
        /// The remove date view model 
        /// </summary>
        /// <param name="dateVm">
        /// The date view model 
        /// </param>
        private void RemoveDateVm(DateVm dateVm)
        {
            this.DateVmCollection.Remove(dateVm);
            this.taskMediator.RemoveClient(dateVm);
            dateVm.NewVmNeeded -= this.OnNewWmNeeded;
        }

        /// <summary>
        ///     The set current view model 
        /// </summary>
        private void SetCurrentVm()
        {
            this.AddDateVm(this.CurrentDateVm.GetPrevious());
            this.AddDateVm(this.CurrentDateVm);
            this.AddDateVm(this.CurrentDateVm.GetNext());
        }
    }
}