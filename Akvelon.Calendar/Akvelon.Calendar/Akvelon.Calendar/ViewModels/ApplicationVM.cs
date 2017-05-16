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
    using Akvelon.Calendar.Models.Interfaces;

    using Xamarin.Forms;

    /// <summary>
    ///     The application view model. Provides a collection of DateCase, selected DateCase.
    /// </summary>
    public class ApplicationVm : MvvmBase
    {
        /// <summary>
        ///     The task Mediator.
        /// </summary>
        private readonly IUserTaskMediator taskMediator;

        /// <summary>
        /// The view model manager.
        /// </summary>
        private readonly IDateVmFactory viewModelManager;

        /// <summary>
        ///     The model.
        /// </summary>
        private IApplicationModel model;

        /// <summary>
        /// The children.
        /// This property is not needed now, but later it should be an important part of the navigation
        /// </summary>
        private ObservableCollection<DateCase> cases;

        /// <summary>
        /// The current child.
        /// </summary>
        private DateCase selectedCase;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationVm"/> class.
        /// </summary>
        /// <param name="model">
        /// The base application model.
        /// </param>
        public ApplicationVm(IApplicationModel model)
        {
            this.Model = model;
            this.taskMediator = this.Model.TaskMediator;
            this.viewModelManager = this.Model.Factory;
            DateInfoModel currentDate = new DateInfoModel(DateTime.Now, this.Model.StartDateType);

            this.SelectedCase = new DateCase(this.viewModelManager.Create(currentDate, this.viewModelManager, this.taskMediator.Tasks));
        }

        /// <summary>
        /// The title.
        /// </summary>
        public string Title => this.SelectedCase.SelectedChild.DateInfo.DateType.ToString();


        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        public ObservableCollection<DateCase> Cases
        {
            get
            {
                return this.cases;
            }

            set
            {
                this.cases = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the selected child.
        /// </summary>
        public DateCase SelectedCase
        {
            get
            {
                return this.selectedCase;
            }

            set
            {
                if (this.selectedCase != null)
                {
                    this.selectedCase.NewVmNeeded -= this.OnNewVm;
                    this.taskMediator.RemoveClient(this.selectedCase);
                }

                value.NewVmNeeded += this.OnNewVm;
                this.taskMediator.AddClient(value);

                this.selectedCase = value;
                this.OnPropertyChanged();          
            }
        }

        /// <summary>
        ///     Gets the model.
        /// </summary>
        public IApplicationModel Model
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
        /// Gets the next view command.
        /// </summary>
        public Command NextViewCommand
        {
            get
            {
                return new Command(
                    (data) =>
                        {
                            if (data is DateRepresentationType)
                            {
                                this.SelectedCase = new DateCase(this.viewModelManager.Create(
                                    new DateInfoModel(DateTime.Now, (DateRepresentationType)data),
                                    this.viewModelManager,
                                    this.taskMediator.Tasks));
                            }
                        });
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
        /// The on new view model needed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="newVm">
        /// The new view model.
        /// </param>
        public void OnNewVm(IDateVm sender, DateVm newVm)
        {
            this.SelectedCase = new DateCase((DateVm)sender);
        }
    }
}