// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserTaskManager.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The user task manager.The user task manager. This class manage all user tasks in current instance of application
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Infrastrucure.UserTasks
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Akvelon.Calendar.Infrastrucure.DateVmBase;
    using Akvelon.Calendar.Models;

    /// <summary>
    ///     The user task manager. This class manage all user tasks in current instance of application
    /// </summary>
    public class UserTaskManager : MvvmBase, ITaskManager
    {
        /// <summary>
        ///     The tasks.
        /// </summary>
        private ObservableCollection<UserTaskModel> tasks;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserTaskManager"/> class.
        /// </summary>
        /// <param name="tasks">
        /// The tasks.
        /// </param>
        public UserTaskManager(List<UserTaskModel> tasks)
        {
            this.tasks = tasks != null ? new ObservableCollection<UserTaskModel>(tasks) : new ObservableCollection<UserTaskModel>();
        }

        /// <summary>
        ///     Gets or sets the tasks.
        /// </summary>
        public ObservableCollection<UserTaskModel> Tasks
        {
            get
            {
                return this.tasks;
            }

            set
            {
                this.tasks = value;
                this.OnPropertyChanged("Tasks");
            }
        }
    }
}