// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskRepository.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   Defines the TaskRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Database.DataBase
{
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;

    using Models;

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
            this.database = new SQLiteConnection(fileHelper.GetDataBasePath(fileName));

            this.database.CreateTable<UserTaskModel>();
        }

        /// <summary>
        /// The get items.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        ///     .
        /// </returns>
        public IEnumerable<UserTaskModel> GetItems()
        {
            return this.database.Table<UserTaskModel>().ToList();
        }

        /// <summary>
        /// The get item.
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
        /// The save item.
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
        /// The remove item.
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
        /// The clear.
        /// </summary>
        public void Clear()
        {
            this.database.DeleteAll<UserTaskModel>();
        }
    }
}
