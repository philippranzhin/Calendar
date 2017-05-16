// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserTaskMediator.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   a mediator between Year/Month/Day/Hour view models and Tasks
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Infrastrucure.UserTasks
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Akvelon.Calendar.Infrastrucure.DateVmBase;
    using Akvelon.Calendar.Models;

    /// <summary>
    /// The user task mediator. Is a mediator between UserTaskManager and the collection of IUserTaskChanged.
    /// </summary>
    public class UserTaskMediator : IUserTaskMediator
    {
        /// <summary>
        ///     The user task manager.
        /// </summary>
        private readonly ITaskManager userTaskManager;

        /// <summary>
        ///     The task clients.
        /// </summary>
        private ObservableCollection<IUserTaskChanged> taskClients;

        /// <summary>
        ///     The _user tasks.
        /// </summary>
        private ReadOnlyObservableCollection<UserTaskModel> tasks;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserTaskMediator"/> class.
        /// </summary>
        /// <param name="manager">
        /// The manager.
        /// </param>
        /// <param name="taskClients">
        /// The task clients.
        /// </param>
        public UserTaskMediator(ITaskManager manager, List<DateVm> taskClients = null)
        {
            this.userTaskManager = manager;
            taskClients?.ForEach(this.AddClient);
        }

        /// <summary>
        ///     Gets the user tasks.
        /// </summary>
        public ReadOnlyObservableCollection<UserTaskModel> Tasks
        {
            get
            {
                if (this.userTaskManager.Tasks == null)
                {
                    return null;
                }

                this.tasks = new ReadOnlyObservableCollection<UserTaskModel>(this.userTaskManager.Tasks);
                return this.tasks;
            }
        }

        /// <summary>
        /// The add client.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        public void AddClient(IUserTaskChanged client)
        {
            if (this.taskClients == null)
            {
                this.taskClients = new ObservableCollection<IUserTaskChanged>();
            }

            if (this.taskClients.Contains(client))
            {
                return;
            }

            this.taskClients.Add(client);

            client.TaskAdded += this.AddTask;
            client.TaskRemoved += this.RemoveTask;
        }

        /// <summary>
        /// The remove client.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        public void RemoveClient(IUserTaskChanged client)
        {
            if (!this.taskClients.Contains(client))
            {
                return;
            }

            this.taskClients.Remove(client);

            client.TaskAdded -= this.AddTask;
            client.TaskRemoved -= this.RemoveTask;
        }

        /// <summary>
        /// The add task.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="task">
        /// The task.
        /// </param>
        private void AddTask(IUserTaskChanged sender, UserTaskModel task)
        {
            if (!this.userTaskManager.Tasks.Contains(task))
            {
                this.userTaskManager.Tasks.Add(task);
            }

            sender.UpdateTasks();           
        }

        /// <summary>
        /// The remove task.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="task">
        /// The task.
        /// </param>
        private void RemoveTask(IUserTaskChanged sender, UserTaskModel task)
        {
            if (this.userTaskManager.Tasks.Contains(task))
            {
                this.userTaskManager.Tasks.Remove(task);
            }

            sender.UpdateTasks();
        }
    }
}