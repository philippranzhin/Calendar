// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppInjection.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   Defines the AppInjection type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar
{
    using System.Collections.Generic;

    using Akvelon.Calendar.Infrastrucure.DateVmBase;
    using Akvelon.Calendar.Infrastrucure.UserTasks;
    using Akvelon.Calendar.Models;
    using Akvelon.Calendar.Models.Enums;
    using Akvelon.Calendar.Models.Interfaces;

    using TinyIoC;

    /// <summary>
    /// The application injection class.
    /// </summary>
    public class AppInjection
    {
        /// <summary>
        /// The register. Create the all input instances for application
        /// </summary>
        /// <param name="appName">
        /// The app name.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="tasks">
        /// The tasks.
        /// </param>
        public static void Register(string appName, DateRepresentationType type, List<UserTaskModel> tasks = null)
        {
            TinyIoCContainer container = TinyIoCContainer.Current;

            container.Register<ITaskManager>(new UserTaskManager(tasks));

            container.Register<IUserTaskMediator>(new UserTaskMediator(container.Resolve<ITaskManager>()));

            container.Register<IDateVmFactory>(new DateVmManager(container.Resolve<IUserTaskMediator>().Tasks));

            TinyIoCContainer.Current.Register<IApplicationModel>(new ApplicationModel(appName,container.Resolve<IDateVmFactory>(), container.Resolve<IUserTaskMediator>(), type));
        }     
    }
}
