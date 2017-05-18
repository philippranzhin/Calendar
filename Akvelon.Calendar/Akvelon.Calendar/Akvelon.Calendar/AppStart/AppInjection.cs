// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppInjection.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   Defines the AppInjection type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

//todo this class not complited
namespace Akvelon.Calendar
{
    using System.Collections.Generic;

    using Akvelon.Calendar.DataBase;
    using Akvelon.Calendar.DataBase.Interfaces;
    using Akvelon.Calendar.Infrastrucure.DateVmBase;
    using Akvelon.Calendar.Infrastrucure.UserTasks;
    using Akvelon.Calendar.Models;
    using Akvelon.Calendar.Models.Enums;
    using Akvelon.Calendar.Models.Interfaces;

    using TinyIoC;

    using Xamarin.Forms;

    /// <summary>
    /// The application injection class.
    /// </summary>
    public class AppInjection
    {
        /// <summary>
        /// </summary>
        /// <param name="appName">
        /// The app name.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        public static void Register(string appName, DateRepresentationType type)
        {
            TinyIoCContainer container = TinyIoCContainer.Current;

            container.Register<ITaskRepository>(new TaskRepository(DependencyService.Get<IFileHelper>(), appName.ToLower()));

            container.Register<ITaskManager, UserTaskManager>();

            container.Register<IUserTaskMediator, UserTaskMediator>();

            container.Register<IDateVmFactory>(new DateVmManager(container.Resolve<IUserTaskMediator>().Tasks));

            container.Register<IApplicationModel>(new ApplicationModel(appName, container.Resolve<IDateVmFactory>(), container.Resolve<IUserTaskMediator>(), type));
            
        }     
    }
}
