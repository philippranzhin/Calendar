// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITaskRepository.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The Repository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Database.DataBase.Interfaces
{
    using System.Collections.Generic;

    using Database.DataBase.Models;

    /// <summary>
    /// The Repository interface.
    /// </summary>
    public interface ITaskRepository
    {
        /// <summary>
        /// Returns all items in database.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        ///     .
        /// </returns>
        IEnumerable<UserTaskModel> GetItems();

        /// <summary>
        /// The get item.
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

        /// <summary>
        /// Removes all items in database.
        /// </summary>
        void Clear();
    }
}
