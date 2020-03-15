// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateVm.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The date
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Infrastrucure.DateVmBase
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using Akvelon.Calendar.Infrastrucure.UserTasks;
    using Akvelon.Calendar.Models;
    using Akvelon.Calendar.ViewModels;

    using Database.DataBase.Models;

    using Xamarin.Forms;

    /// <summary>
    ///     The date view model abstract class. 
    /// Describes the objects, that can give the basic information about date, the interface add/remove tasks in date, the interface to get next/previous  date view model.
    /// </summary>
    public abstract class DateVm : IDateVm
    {
        /// <summary>
        /// The factory.
        /// </summary>
        private readonly IDateVmFactory factory;

        /// <summary>
        ///     The date.
        /// </summary>
        private readonly DateInfoModel dateInfo;

        /// <summary>
        /// The task mediator.
        /// </summary>
        private readonly IUserTaskMediator taskMediator;

        /// <summary>
        /// The task view model.
        /// </summary>
        private IDateVm taskVm;

        /// <summary>
        ///     The children.
        /// </summary>
        private ObservableCollection<DateVm> children;

        /// <summary>
        /// Initializes a new instance of the <see cref="DateVm"/> class.
        /// </summary>
        /// <param name="dateInfo">
        /// The date info.
        /// </param>
        /// <param name="factory">
        /// The factory.
        /// </param>
        /// <param name="taskMediator">
        /// The task mediator.
        /// </param>
        protected DateVm(
            DateInfoModel dateInfo,
            IDateVmFactory factory,
            IUserTaskMediator taskMediator)
        {
            this.dateInfo = dateInfo;
            this.taskMediator = taskMediator;
            this.factory = factory;
            this.UpdateTasks();
        }

        /// <summary>
        ///     The new view model needed.
        /// </summary>
        public event DateVmHandler NewVmNeeded;

        /// <summary>
        ///     The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     The task added.
        /// </summary>
        public event TaskHandler TaskAdded;

        /// <summary>
        ///     The task removed.
        /// </summary>
        public event TaskHandler TaskRemoved;

        /// <summary>
        ///  Gets the add task command.
        ///  Parameter must be of type "DateTime"
        /// </summary>
        public Command CancelTaskCommand
        {
            get
            {
                return new Command(() => this.TaskVm = null);
            }
        }

        /// <summary>
        ///  Gets the add task command.
        ///  Parameter must be of type "DateTime"
        /// </summary>
        public Command AddTaskCommand
        {
            get
            {
                return new Command((date) => this.TaskVm = new TaskVm(this.taskMediator, this.factory, this.DateInfo)
                                                               {
                                                                   InputDate = (DateTime)date,
                                                                   InputEndDate = (DateTime)date
                });
            }
        }

        /// <summary>
        /// Gets or sets the task view model.
        /// </summary>
        public IDateVm TaskVm
        {
            get
            {
                return this.taskVm;
            }

            set
            {
                this.taskVm = value;

                if (value != null)
                {
                    this.taskVm.TaskAdded += (sender, task) =>
                        {
                            this.OnTaskAdded(this, task);
                            this.TaskVm = null;
                        };
                }

                this.OnPropertyChanged();
                this.OnPropertyChanged("IsTaskAdding");
            }
        }

        /// <summary>
        /// The is task adding.
        /// </summary>
        public bool IsTaskAdding => this.TaskVm != null;

        /// <summary>
        ///     The date info.
        /// </summary>
        public DateInfoModel DateInfo => this.dateInfo;

        /// <summary>
        ///     The is current date.
        /// </summary>
        public bool IsCurrentDate => this.IsDateEqual(DateTime.Now);


        /// <summary>
        ///     Gets the name.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        ///     Gets the next view command.
        /// </summary>
        public Command NextViewCommand
        {
            get
            {
                return new Command(() => this.OnNewVmNeeded(this));
            }
        }

        /// <summary>
        ///     Gets the user tasks.
        /// </summary>
        public virtual ReadOnlyObservableCollection<UserTaskModel> UserTasks
        {
            get
            {
                ObservableCollection<UserTaskModel> result =
                    new ObservableCollection<UserTaskModel>(this.taskMediator.Tasks.Where(task => this.IsDateEqual(task.Date) || this.IsDateEqual(task.EndDate)));

                return new ReadOnlyObservableCollection<UserTaskModel>(result);
            }
        }

        /// <summary>
        ///     Gets the next date.
        /// </summary>
        public abstract DateInfoModel NextDate { get; }

        /// <summary>
        ///     Gets the previous date.
        /// </summary>
        public abstract DateInfoModel PreviousDate { get; }

        /// <summary>
        ///     Gets the children.
        /// </summary>
        public ReadOnlyObservableCollection<DateVm> Children
        {
            get
            {
                if (this.children == null)
                {
                    this.children = new ObservableCollection<DateVm>();
                    this.FillChildren();
                }

                return new ReadOnlyObservableCollection<DateVm>(this.children);
            }
        }

        /// <summary>
        ///     The get next.
        /// </summary>
        /// <returns>
        ///     The <see cref="DateVm" />.
        /// </returns>
        public virtual DateVm GetNext()
        {
            return this.factory.Create(this.NextDate, this.factory, this.taskMediator);
        }

        /// <summary>
        ///     The get previous.
        /// </summary>
        /// <returns>
        ///     The <see cref="DateVm" />.
        /// </returns>
        public virtual DateVm GetPrevious()
        {
            return this.factory.Create(this.PreviousDate, this.factory, this.taskMediator);
        }

        /// <summary>
        ///     The update tasks.
        /// </summary>
        public void UpdateTasks()
        {
            this.OnPropertyChanged("UserTasks");

            if (this.children == null || this.children.Count <= 0)
            {
                return;
            }

            foreach (DateVm child in this.children)
            {
                child.UpdateTasks();
            }
        }

        /// <summary>
        /// The is date equal. Returns "true" if the Date property of current instance is equal to the date parameter
        /// </summary>
        /// <param name="date">
        /// The date.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public virtual bool IsDateEqual(DateInfoModel date)
        {
            return this.DateInfo.DateType == date.DateType && this.IsDateEqual(date.Date);
        }

        /// <summary>
        /// The is date equal. Returns "true" if the Date property of current instance is equal to the date parameter
        /// </summary>
        /// <param name="date">
        /// The date.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public abstract bool IsDateEqual(DateTime date);

        /// <summary>
        /// A method that is called only once when the children property is called the first time. 
        /// The parent class expects children to use the RegisterChild method in this method for each of their own children
        /// </summary>
        protected abstract void FillChildren();

        /// <summary>
        /// The register child.
        /// </summary>
        /// <param name="childDate">
        /// The child date.
        /// </param>
        protected virtual void RegisterChild(DateInfoModel childDate)
        {
            DateVm child = this.factory.Create(childDate, this.factory, this.taskMediator);
            child.NewVmNeeded += this.OnNewVmNeeded;
            child.TaskAdded += (sender, task) =>
                {
                    this.OnTaskAdded(this, task);
                    this.OnTaskAdded(sender, task);
                };
            child.TaskRemoved += (sender, task) =>
                {
                    this.OnTaskRemoved(this, task);
                    this.OnTaskRemoved(sender, task);
                };
            this.children.Add(child);
            this.OnPropertyChanged("Children");
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
        /// The on property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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