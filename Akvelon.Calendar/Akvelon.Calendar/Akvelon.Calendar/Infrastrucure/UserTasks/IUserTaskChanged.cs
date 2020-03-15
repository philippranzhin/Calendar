// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserTaskChanged.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The UserTaskChanged interface.
//   This interface describes the objects, that can notify on adding/removing tasks, and can get notifications on
//   changed tasks state
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Infrastrucure.UserTasks
{
    using System.ComponentModel;

    /// <summary>
    ///     The UserTaskChanged interface.
    ///     This interface describes the objects, that can notify on adding/removing tasks, and can get notifications on
    ///     changed tasks state
    /// </summary>
    public interface IUserTaskChanged : INotifyPropertyChanged
    {
        /// <summary>
        ///     The task added.
        /// </summary>
        event TaskHandler TaskAdded;

        /// <summary>
        ///     The task removed.
        /// </summary>
        event TaskHandler TaskRemoved;

        /// <summary>
        ///     The update tasks.
        /// </summary>
        void UpdateTasks();
    }
}