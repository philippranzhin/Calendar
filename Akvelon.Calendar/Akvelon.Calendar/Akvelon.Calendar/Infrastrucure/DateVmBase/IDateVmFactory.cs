// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDateVmFactory.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   Defines the IDateVmFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Infrastrucure.DateVmBase
{
    using System.Collections.ObjectModel;

    using Akvelon.Calendar.Infrastrucure.UserTasks;
    using Akvelon.Calendar.Models;

    /// <summary>
    /// The DateVmFactory interface. Describes object, that can create DateVm instances.
    /// </summary>
    public interface IDateVmFactory
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="dateInfo">
        /// The date info.
        /// </param>
        /// <param name="factory">
        /// The factory.
        /// </param>
        /// <param name="taskMediator">
        /// The task mediator.
        /// </param>
        /// <returns>
        /// The <see cref="DateVm"/>.
        /// </returns>
        DateVm Create(DateInfoModel dateInfo, IDateVmFactory factory, IUserTaskMediator taskMediator);
    }
}
