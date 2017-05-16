// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IApplicationModel.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   Defines the IApplicationModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Models.Interfaces
{
    using Akvelon.Calendar.Infrastrucure.DateVmBase;
    using Akvelon.Calendar.Infrastrucure.UserTasks;
    using Akvelon.Calendar.Models.Enums;

    /// <summary>
    /// The base application model interface. Describes objects, that can be a model of current application.
    /// </summary>
    public interface IApplicationModel
    {
        /// <summary>
        /// Gets or sets application name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the base date view model factory of current application.
        /// </summary>
        IDateVmFactory Factory { get; set; }

        /// <summary>
        /// Gets or sets the base task mediator of current application.
        /// </summary>
        IUserTaskMediator TaskMediator { get; set; }

        /// <summary>
        /// Gets or sets the start date type of current application.
        /// </summary>
        DateRepresentationType StartDateType { get; set; }
    }
}
