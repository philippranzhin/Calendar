// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskHandler.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The task handler.
//   This delegate describes the event, that contain information about own sender and user task
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Infrastrucure.UserTasks
{
    using Database.DataBase.Models;

    /// <summary>
    ///     The task handler.
    ///     This delegate describes the event, that contain information about own sender and user task
    /// </summary>
    /// <param name="sender">
    ///     The sender.
    /// </param>
    /// <param name="task">
    ///     The task.
    /// </param>
    public delegate void TaskHandler(IUserTaskChanged sender, UserTaskModel task);
}