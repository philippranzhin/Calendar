// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskRepository.cs" company="Akvelon">
//   Philipp ranzhin
// </copyright>
// <summary>
//   The task repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.DataBase
{
    using System.Collections.Generic;
    using System.Linq;

    using Akvelon.Calendar.DataBase.Interfaces;
    using Akvelon.Calendar.Models;

    using SQLite;

    /// <summary>
    /// The task repository.
    /// </summary>
    public class TaskRepository : ITaskRepository
    {
        /// <summary>
        /// The database.
        /// </summary>
        private readonly SQLiteConnection database;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskRepository"/> class.
        /// </summary>
        /// <param name="fileHelper">
        /// The file helper.
        /// </param>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        public TaskRepository(IFileHelper fileHelper, string fileName)
        {
            // todo get name from app model
            this.database = new SQLiteConnection(fileHelper.GetDateBasePath(fileName));

            this.database.CreateTable<UserTaskModel>();
        }

        /// <summary>
        /// Returns all items in database.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<UserTaskModel> GetItems()
        {
            return this.database.Table<UserTaskModel>().ToList();
        }

        /// <summary>
        /// Returns the element with the specified id from the database.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="UserTaskModel"/>.
        /// </returns>
        public UserTaskModel GetItem(int id)
        {
            return this.database.Get<UserTaskModel>(id);
        }

        /// <summary>
        /// Saves item in database and return it id.
        /// </summary>
        /// <param name="userTask">
        /// The user task.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int SaveItem(UserTaskModel userTask)
        {
            return this.database.Insert(userTask);
        }

        /// <summary>
        ///  Removes item in database and return result.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int RemoveItem(int id)
        {
            return this.database.Delete<UserTaskModel>(id);
        }

        /// <summary>
        /// Removes all items in database.
        /// </summary>
        public void Clear()
        {
            this.database.DeleteAll<UserTaskModel>();
        }
    }
}
