// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserTaskMediator.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The UserTaskMediator interface. Describes objects, that can adds and removes the own clients, and provides ability to get the task collection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Infrastrucure.UserTasks
{
    using System.Collections.ObjectModel;

    using Database.DataBase.Models;

    /// <summary>
    /// The UserTaskMediator interface. Describes objects, that can adds and removes the own clients, and provides ability to get the task collection.
    /// </summary>
    public interface IUserTaskMediator
    {
        /// <summary>
        /// Gets the immutable user task collection.
        /// </summary>
        ReadOnlyObservableCollection<UserTaskModel> Tasks { get; }

        /// <summary>
        /// Adds a client
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        void AddClient(IUserTaskChanged client);


        /// <summary>
        /// Removes a client
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        void RemoveClient(IUserTaskChanged client);
    }
}
