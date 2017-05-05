// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationVm.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The application view model 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.ViewModels
{
    using System;
    using System.Collections.ObjectModel;

    using Akvelon.Calendar.Infrastrucure.DateVmBase;
    using Akvelon.Calendar.Infrastrucure.UserTasks;
    using Akvelon.Calendar.Models;
    using Akvelon.Calendar.Models.Enums;

    /// <summary>
    ///     The application view model. Provides a collection of DateCase, selected DateCase.
    /// </summary>
    public class ApplicationVm : MvvmBase
    {
        /// <summary>
        ///     The task Mediator.
        /// </summary>
        private readonly UserTaskMediator taskMediator;

        /// <summary>
        ///     The current date case.
        /// </summary>
        private DateCaseVm currentDateCase;

        /// <summary>
        ///     The date cases.
        /// </summary>
        private ObservableCollection<DateCaseVm> dateCases = new ObservableCollection<DateCaseVm>();

        /// <summary>
        ///     The model.
        /// </summary>
        private ApplicationModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationVm"/> class.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <param name="dateType">
        /// The date type.
        /// </param>
        public ApplicationVm(ApplicationModel model, DateInfoType dateType = DateInfoType.Year)
        {
            this.taskMediator = new UserTaskMediator();
            this.model = model;
            DateVmManager manager = new DateVmManager(this.taskMediator.Tasks);
            DateInfoModel currentDate = new DateInfoModel(DateTime.Now, dateType);
            this.AddDateCase(new DateCaseVm(manager.GetOrCreate(currentDate), this.taskMediator));
        }

        /// <summary>
        ///     Gets or sets the current date case.
        /// </summary>
        public DateCaseVm CurrentDateCase
        {
            get
            {
                return this.currentDateCase;
            }

            set
            {
                this.currentDateCase = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets the date cases.
        /// </summary>
        public ObservableCollection<DateCaseVm> DateCases
        {
            get
            {
                return this.dateCases;
            }

            private set
            {
                this.dateCases = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets the model.
        /// </summary>
        public ApplicationModel Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                this.model = value;
                this.OnPropertyChanged("Model");
            }
        }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        public string Name
        { 
            get
            {
                return this.Model.Name;
            }

            private set
            {
                this.Model.Name = value;
                this.OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// The add date case.
        /// </summary>
        /// <param name="dateCase">
        /// The date case.
        /// </param>
        private void AddDateCase(DateCaseVm dateCase)
        {
            this.DateCases.Add(dateCase);

            dateCase.NewVmNeeded += (sender, newVm) =>
                {
                    if (this.CurrentDateCase == dateCase)
                    {
                        this.AddDateCase(new DateCaseVm(newVm, this.taskMediator));
                    }
                };
            this.CurrentDateCase = dateCase;
        }
    }
}