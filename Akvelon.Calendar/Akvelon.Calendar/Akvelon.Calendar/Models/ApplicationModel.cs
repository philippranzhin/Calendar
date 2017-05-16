// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationModel.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The application model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Models
{
    using Akvelon.Calendar.Infrastrucure.DateVmBase;
    using Akvelon.Calendar.Infrastrucure.UserTasks;
    using Akvelon.Calendar.Models.Enums;
    using Akvelon.Calendar.Models.Interfaces;

    /// <summary>
    ///     The application model.
    /// </summary>
    public class ApplicationModel : IApplicationModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationModel"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="factory">
        /// The factory.
        /// </param>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        public ApplicationModel(string name, IDateVmFactory factory, IUserTaskMediator mediator, DateRepresentationType type)
        {
            this.Name = name;
            this.Factory = factory;
            this.TaskMediator = mediator;
            this.StartDateType = type;
        }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the factory.
        /// </summary>
        public IDateVmFactory Factory { get; set; }

        /// <summary>
        /// Gets or sets the task mediator.
        /// </summary>
        public IUserTaskMediator TaskMediator { get; set; }

        /// <summary>
        /// Gets or sets the start date type.
        /// </summary>
        public DateRepresentationType StartDateType { get; set; }
    }
}