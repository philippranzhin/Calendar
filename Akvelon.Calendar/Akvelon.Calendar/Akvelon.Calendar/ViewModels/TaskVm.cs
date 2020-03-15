// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskVm.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   Defines the TaskVm type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


// TODO need to resolve problem with an observe ability of the DateInfoModel 
// (if it will be observable, I can to remove the input properies (such as InputName, InputDate etc.), but I not sure, that this is a correct way)
namespace Akvelon.Calendar.ViewModels
{
    using System;

    using Akvelon.Calendar.Infrastrucure.DateVmBase;
    using Akvelon.Calendar.Infrastrucure.UserTasks;
    using Akvelon.Calendar.Models;
    using Akvelon.Calendar.Models.Enums;

    using Database.DataBase.Models;

    using Xamarin.Forms;

    /// <summary>
    /// The add task view model.
    /// </summary>
    public class TaskVm : MvvmBase, IDateVm
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
        /// The new task.
        /// </summary>
        private UserTaskModel newTask;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskVm"/> class.
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
        /// <param name="task">
        /// The task.
        /// </param>
        public TaskVm(IUserTaskMediator mediator, IDateVmFactory factory, DateInfoModel dateInfo, UserTaskModel task = null)
        {

            // sync the save possibility
            this.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName != "CanSave" && args.PropertyName != "NewTask")
                    {
                        this.OnPropertyChanged("CanSave");
                    }
                };

            this.OldTask = task ?? new UserTaskModel()
                                       {
                                           Date = DateTime.Now,
                                           EndDate = DateTime.Now
                                       };

            this.taskMediator = mediator;
            this.factory = factory;
            this.dateInfo = dateInfo;
            this.NewTask = (UserTaskModel)this.OldTask.Clone();
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
        public bool CanSave
        {
            get
            {
                if (
                    this.NewTask != null &&
                    this.OldTask.CompareTo(this.newTask) != 0 &&
                    !string.IsNullOrWhiteSpace(this.newTask.Name) &&
                    !string.IsNullOrWhiteSpace(this.newTask.Description) &&
                    !string.IsNullOrWhiteSpace(this.newTask.Place))
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
                            this.OnTaskRemoved(this, this.OldTask);
                            this.OnTaskAdded(this, this.NewTask);
                        },
                    () => this.CanSave);
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
                    this.factory.Create(
                        new DateInfoModel(this.newTask.Date, this.dateInfo.DateType),
                        this.factory,
                        this.taskMediator));
            }
        }

        /// <summary>
        /// The on new view model needed.
        /// </summary>
        /// <param name="viewModel">
        /// The view model.
        /// </param>
        protected virtual void OnNewVmNeeded(IDateVm viewModel)
        {
            this.NewVmNeeded?.Invoke(viewModel);
        }


        /// <summary>
        /// The on task added.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="task">
        /// The task.
        /// </param>
        protected virtual void OnTaskAdded(IUserTaskChanged sender, UserTaskModel task)
        {
            this.TaskAdded?.Invoke(sender, task);
        }

        /// <summary>
        /// The on task removed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="task">
        /// The task.
        /// </param>
        protected virtual void OnTaskRemoved(IUserTaskChanged sender, UserTaskModel task)
        {
            this.TaskRemoved?.Invoke(sender, task);
        }
    }
}
