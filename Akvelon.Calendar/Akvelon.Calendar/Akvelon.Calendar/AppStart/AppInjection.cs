// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppInjection.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   Defines the AppInjection type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// TODO this class not complited
namespace Akvelon.Calendar
{
    using Akvelon.Calendar.Infrastrucure.DateVmBase;
    using Akvelon.Calendar.Infrastrucure.UserTasks;
    using Akvelon.Calendar.Models;
    using Akvelon.Calendar.Models.Enums;
    using Akvelon.Calendar.Models.Interfaces;

    using Database.DataBase;
    using Database.DataBase.Interfaces;

    using TinyIoC;

    using Xamarin.Forms;

    /// <summary>
    /// The application injection class.
    /// </summary>
    public class AppInjection
    {
        /// <summary>
        /// The get instance.
        /// </summary>
        /// <param name="appName">
        /// The app name.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="App"/>.
        /// </returns>
        public static App GetInstance(string appName, DateRepresentationType type)
        {
            TinyIoCContainer container = new TinyIoCContainer();

            container.Register<ITaskRepository>(new TaskRepository(DependencyService.Get<IFileHelper>(), appName.ToLower()));

            container.Register<ITaskManager, UserTaskManager>();

            container.Register<IUserTaskMediator, UserTaskMediator>();

            container.Register<IDateVmFactory, DateVmManager>();

            container.Register<IApplicationModel>(new ApplicationModel(appName, container.Resolve<IDateVmFactory>(), container.Resolve<IUserTaskMediator>(), type));    
            
            return new App(container.Resolve<IApplicationModel>());
        }     
    }
}
