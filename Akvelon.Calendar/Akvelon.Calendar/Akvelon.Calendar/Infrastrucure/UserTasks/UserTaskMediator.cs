using System.Collections.Generic;
using System.Collections.ObjectModel;
using Akvelon.Calendar.Models;

namespace Akvelon.Calendar.Infrastrucure.UserTasks
{
    /// <summary>
    /// a mediator between Year/Month/Day/Hour view models and Tasks
    /// </summary>
    public class UserTaskMediator
    {
        #region fields
        private ObservableCollection<IUserTaskChanged> _taskClients;
        private readonly UserTaskUtil _userTaskUtil;
        private ReadOnlyObservableCollection<UserTaskModel> _userTasks;
        #endregion

        #region constructor
        public UserTaskMediator(List<IUserTaskChanged> taskClients=null)
        {          
            _userTaskUtil = new UserTaskUtil();
            taskClients?.ForEach(AddClient);
        }
        #endregion

        #region methods
        private void AddMethod(IUserTaskChanged sender, UserTaskModel task)
        {
            if(!_userTaskUtil.Tasks.Contains(task))
                _userTaskUtil.Tasks.Add(task);

            sender.UpdateTasks();
        }

        private void RemoveMethod(IUserTaskChanged sender, UserTaskModel task)
        {
            if (_userTaskUtil.Tasks.Contains(task))
                _userTaskUtil.Tasks.Remove(task);

            sender.UpdateTasks();
        }

        public void AddClient(IUserTaskChanged client)
        {
            if(_taskClients==null)
                _taskClients=new ObservableCollection<IUserTaskChanged>();

            if (_taskClients.Contains(client))
                return;

            _taskClients.Add(client);

            client.TaskAdded += AddMethod;
            client.TaskRemoved += AddMethod;
        }

        public void RemoveClient(IUserTaskChanged client)
        {
            if (!_taskClients.Contains(client))
                return;

            _taskClients.Remove(client);

            client.TaskAdded -= AddMethod;
            client.TaskRemoved -= RemoveMethod;
        }
        #endregion

        #region properties   
        public ReadOnlyObservableCollection<UserTaskModel> UserTasks
        {
            get
            {
                if (_userTaskUtil.Tasks == null)
                    return null;

                _userTasks=new ReadOnlyObservableCollection<UserTaskModel>(_userTaskUtil.Tasks);
                return _userTasks;                
            }
        }
        #endregion
    }
}
