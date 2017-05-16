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

    using Akvelon.Calendar.Models;

    /// <summary>
    /// The TaskManager interface. Describes the objects, that can ceep collection of user task model
    /// </summary>
    public interface ITaskManager
    {
        /// <summary>
        /// Gets the tasks.
        /// </summary>
        ObservableCollection<UserTaskModel> Tasks { get; }
    }
}
