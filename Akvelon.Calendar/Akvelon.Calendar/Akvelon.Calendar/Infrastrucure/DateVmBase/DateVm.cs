﻿// --------------------------------------------------------------------------------------------------------------------
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
    using System.Runtime.CompilerServices;

    using Akvelon.Calendar.Infrastrucure.UserTasks;
    using Akvelon.Calendar.Models;

    using Xamarin.Forms;

    /// <summary>
    ///     The date view model abstract class. 
    /// Describes the objects, that can give the basic information about date, the interface add/remove tasks in date, the interface to get next/previous  DateVm.
    /// </summary>
    public abstract class DateVm : IDateVm
    {
        /// <summary>
        ///     The date.
        /// </summary>
        protected readonly DateInfoModel Date;

        /// <summary>
        ///     The date view models manager.
        /// </summary>
        protected readonly IDateVmFactory Factory;

        /// <summary>
        ///     The _tasks.
        /// </summary>
        protected readonly ReadOnlyObservableCollection<UserTaskModel> Tasks;

        /// <summary>
        /// Initializes a new instance of the <see cref="DateVm"/> class.
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
        protected DateVm(
            DateInfoModel dateInfo,
            IDateVmFactory factory,
            ReadOnlyObservableCollection<UserTaskModel> tasks)
        {
            this.Date = dateInfo;
            this.Tasks = tasks;
            this.Factory = factory;
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
        ///     Gets the add task command.
        /// </summary>
        public Command AddTaskCommand
        {
            get
            {
                return new Command(() => { this.TaskAdded?.Invoke(this, new UserTaskModel(this.Date.Date)); });
            }
        }

        /// <summary>
        ///     The date info.
        /// </summary>
        public DateInfoModel DateInfo => this.Date;

        /// <summary>
        ///     The is current date.
        /// </summary>
        public bool IsCurrentDate => this.DateInfo.Compare(DateTime.Now);

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
                return new Command(sender => { this.OnNewWmNeeded(this, sender as DateVm); });
            }
        }

        /// <summary>
        ///     Gets the user tasks.
        /// </summary>
        public abstract ReadOnlyObservableCollection<UserTaskModel> UserTasks { get; }

        /// <summary>
        ///     Gets the next date.
        /// </summary>
        protected abstract DateInfoModel NextDate { get; }

        /// <summary>
        ///     Gets the previous date.
        /// </summary>
        protected abstract DateInfoModel PreviousDate { get; }

        /// <summary>
        ///     The get next.
        /// </summary>
        /// <returns>
        ///     The <see cref="DateVm" />.
        /// </returns>
        public virtual DateVm GetNext()
        {
            return this.Factory.Create(this.NextDate, this.Factory, this.Tasks);
        }

        /// <summary>
        ///     The get previous.
        /// </summary>
        /// <returns>
        ///     The <see cref="DateVm" />.
        /// </returns>
        public virtual DateVm GetPrevious()
        {
            return this.Factory.Create(this.PreviousDate, this.Factory, this.Tasks);
        }

        /// <summary>
        ///     The update tasks.
        /// </summary>
        public void UpdateTasks()
        {
            this.OnPropertyChanged("UserTasks");
        }

        /// <summary>
        /// The on new view model needed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="newDateVm">
        /// The new date view model.
        /// </param>
        protected virtual void OnNewWmNeeded(IDateVm sender, DateVm newDateVm)
        {
            this.NewVmNeeded?.Invoke(sender, newDateVm);
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