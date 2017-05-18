// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDateVm.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The Date view model interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Infrastrucure.DateVmBase
{
    using Akvelon.Calendar.Infrastrucure.UserTasks;

    /// <summary>
    /// The interface of the date representation model. Describes objects that can be a view model and can notify the need for a new view model.
    /// </summary>
    public interface IDateVm : IUserTaskChanged
    {
        /// <summary>
        ///     The new view model needed.
        /// </summary>
        event DateVmHandler NewVmNeeded;

        /// <summary>
        /// Gets the name.
        /// </summary>
        string Name { get; }
    }
}