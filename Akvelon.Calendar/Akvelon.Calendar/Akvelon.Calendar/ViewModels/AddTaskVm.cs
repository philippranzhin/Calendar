// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddTaskVm.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   Defines the AddTaskVm type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.ViewModels
{
    using System;
    using System.Linq;

    using Akvelon.Calendar.Infrastrucure.DateVmBase;
    using Akvelon.Calendar.Infrastrucure.UserTasks;
    using Akvelon.Calendar.Models;

    using Xamarin.Forms;

    /// <summary>
    /// The add task view model.
    /// </summary>
    public class AddTaskVm : MvvmBase, IDateVm
    {
        /// <summary>
        /// The task mediator.
        /// </summary>
        private readonly IUserTaskMediator taskMediator;

        /// <summary>
        /// The factory.
        /// </summary>
        private readonly IDateVmFactory factory;

        /// <summary>
        /// The factory.
        /// </summary>
        private readonly DateInfoModel dateInfo;

        /// <summary>
        /// The old task.
        /// </summary>
        private UserTaskModel oldTask;

        /// <summary>
        /// The old task.
        /// </summary>
        private UserTaskModel newTask;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddTaskVm"/> class.
        /// </summary>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        /// <param name="task">
        /// The task.
        /// </param>
        /// <param name="dateInfo">
        /// The date info.
        /// </param>
        public AddTaskVm(IUserTaskMediator mediator, UserTaskModel task, DateInfoModel dateInfo)
        {
            this.OldTask = task;
            this.taskMediator = mediator;
            this.dateInfo = dateInfo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddTaskVm"/> class.
        /// </summary>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        /// <param name="factory">
        /// The factory.
        /// </param>
        /// <param name="dateInfo">
        /// The date info.
        /// </param>
        public AddTaskVm(IUserTaskMediator mediator, IDateVmFactory factory ,DateInfoModel dateInfo)
        {
            this.OldTask = new UserTaskModel() { Date = dateInfo.Date, EndDate = dateInfo.Date};
            this.taskMediator = mediator;
            this.factory = factory;
            this.dateInfo = dateInfo;
        }

        /// <summary>
        /// The task added.
        /// </summary>
        public event TaskHandler TaskAdded;

        /// <summary>
        /// The task removed.
        /// </summary>
        public event TaskHandler TaskRemoved;

        /// <summary>
        /// The new view model needed.
        /// </summary>
        public event DateVmHandler NewVmNeeded;

        /// <summary>
        /// The name.
        /// </summary>
        public string Name => this.newTask.Name;

        /// <summary>
        /// Gets a value indicating whether is can save.
        /// </summary>
        public bool IsCanSave
        {
            get
            {
                if (this.OldTask.CompareTo(this.newTask) != 0 &&
                    !string.IsNullOrWhiteSpace(this.newTask.Name))
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Gets the save command.
        /// </summary>
        public Command SaveCommand
        {
            get
            {
                return new Command(
                    () =>
                        {
                            this.TaskRemoved?.Invoke(this, this.OldTask);
                            this.TaskAdded?.Invoke(this, this.NewTask);                            
                        },
                    () => this.IsCanSave);
            }
        }

        /// <summary>
        /// Gets or sets the new task name.
        /// </summary>
        public string InputName
        {
            get
            {
                return this.NewTask.Name;
            }

            set
            {
                this.NewTask.Name = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the new task description.
        /// </summary>
        public string InputDescription
        {
            get
            {
                return this.NewTask.Description;
            }

            set
            {
                this.NewTask.Description = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the new task place.
        /// </summary>
        public string InputPlace
        {
            get
            {
                return this.NewTask.Place;
            }

            set
            {
                this.NewTask.Place = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the new task date.
        /// </summary>
        public DateTime InputDate
        {
            get
            {
                return this.NewTask.Date;
            }

            set
            {
                this.NewTask.Date = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the new task endDate.
        /// </summary>
        public DateTime InputEndDate
        {
            get
            {
                return this.NewTask.EndDate;
            }

            set
            {
                this.NewTask.EndDate = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the old task.
        /// </summary>
        public UserTaskModel OldTask
        {
            get
            {
                return this.oldTask;
            }

            private set
            {
                this.oldTask = value;
                this.OnPropertyChanged();
                this.NewTask = (UserTaskModel)this.OldTask.Clone();
            }
        }

        /// <summary>
        /// Gets the new task.
        /// </summary>
        public UserTaskModel NewTask
        {
            get
            {
                return this.newTask;
            }

            private set
            {
                this.newTask = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// The update tasks.
        /// </summary>
        public void UpdateTasks()
        {
            if (this.taskMediator.Tasks.Contains(this.NewTask))
            {
                this.NewVmNeeded?.Invoke(
                    this,
                    this.factory.Create(
                    new DateInfoModel(this.newTask.Date, this.dateInfo.DateType),
                    this.factory,
                    this.taskMediator));
            }
        }
    }
}
