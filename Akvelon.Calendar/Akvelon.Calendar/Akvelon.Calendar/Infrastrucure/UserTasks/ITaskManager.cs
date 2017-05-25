// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITaskManager.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   Defines the ITaskManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Infrastrucure.UserTasks
{
    using System.Collections.ObjectModel;

    using Database.DataBase.Models;

    /// <summary>
    /// The TaskManager interface.
    /// </summary>
    public interface ITaskManager
    {
        /// <summary>
        /// Gets the tasks.
        /// </summary>
        ObservableCollection<UserTaskModel> Tasks { get; }
    }
}
