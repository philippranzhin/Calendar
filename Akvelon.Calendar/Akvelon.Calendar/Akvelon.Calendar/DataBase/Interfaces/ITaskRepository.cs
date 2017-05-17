// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITaskRepository.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The Repository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.DataBase.Interfaces
{
    using System.Collections.Generic;

    using Akvelon.Calendar.Models;

    /// <summary>
    /// The Repository interface.
    /// </summary>
    public interface ITaskRepository
    {
        /// <summary>
        /// Returns all items in database.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<UserTaskModel> GetItems();

        /// <summary>
        /// Returns the element with the specified id from the database.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="UserTaskModel"/>.
        /// </returns>
        UserTaskModel GetItem(int id);

        /// <summary>
        /// Saves item in database and return it id.
        /// </summary>
        /// <param name="userTask">
        /// The user task.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int SaveItem(UserTaskModel userTask);

        /// <summary>
        ///  Removes item in database and return result.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int RemoveItem(int id);
    }
}
