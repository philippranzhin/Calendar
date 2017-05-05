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
    using System.Collections.ObjectModel;

    using Akvelon.Calendar.Infrastrucure.DateVmBase;
    using Akvelon.Calendar.Models;

    /// <summary>
    ///     The user task manager. This class manage all user tasks in current instance of application
    /// </summary>
    public class UserTaskManager : MvvmBase
    {
        /// <summary>
        ///     The _tasks.
        /// </summary>
        private ObservableCollection<UserTaskModel> tasks = new ObservableCollection<UserTaskModel>();

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