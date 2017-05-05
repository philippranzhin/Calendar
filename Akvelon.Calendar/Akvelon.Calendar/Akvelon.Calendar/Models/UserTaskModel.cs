// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserTaskModel.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The user task model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Models
{
    using System;

    using Akvelon.Calendar.Infrastrucure.DateVmBase;

    /// <summary>
    ///     The user task model.
    /// </summary>
    public class UserTaskModel : MvvmBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserTaskModel"/> class.
        /// </summary>
        /// <param name="date">
        /// The date.
        /// </param>
        public UserTaskModel(DateTime date)
        {
            this.TaskDate = date;
        }

        /// <summary>
        ///     Gets the task date.
        /// </summary>
        public DateTime TaskDate { get; }
    }
}