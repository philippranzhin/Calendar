using System.Collections.ObjectModel;

namespace Akvelon.Calendar.Infrastrucure.UserTasks
{
    public class UserTaskUtil : MVVMBase
    {
        #region fields
        private ObservableCollection<UserTask> _tasks;
        #endregion

        #region constructor
        public UserTaskUtil() { }
        #endregion

        #region properties
        public ObservableCollection<UserTask> Tasks
        {
            get { return _tasks; }
            set
            {
                _tasks = value;
                OnPropertyChanged("Tasks");
            }
        }
        #endregion

    }
}
