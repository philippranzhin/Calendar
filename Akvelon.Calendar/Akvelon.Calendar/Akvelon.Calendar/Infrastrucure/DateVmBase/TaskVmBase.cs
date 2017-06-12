// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskVmBase.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The task vm base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Infrastrucure.DateVmBase
{
    using System.ComponentModel;

    using Akvelon.Calendar.Infrastrucure.UserTasks;

    using Database.DataBase.Models;

    /// <summary>
    /// The task view model base class.
    /// </summary>
    public abstract class TaskVmBase : MvvmBase,IDateVm
    {

        /// <summary>
        ///     The new view model needed.
        /// </summary>
        public event DateVmHandler NewVmNeeded;

        /// <summary>
        ///     The task added.
        /// </summary>
        public event TaskHandler TaskAdded;

        /// <summary>
        ///     The task removed.
        /// </summary>
        public event TaskHandler TaskRemoved;

        /// <summary>
        /// Gets the name.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The update tasks.
        /// </summary>
        public virtual void UpdateTasks()
        {            
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