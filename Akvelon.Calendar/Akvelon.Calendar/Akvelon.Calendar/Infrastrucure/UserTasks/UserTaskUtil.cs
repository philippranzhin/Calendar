using System.Collections.ObjectModel;
using Akvelon.Calendar.Models;

namespace Akvelon.Calendar.Infrastrucure.UserTasks
{
    public class UserTaskUtil : MVVMBase
    {
        #region fields
        private ObservableCollection<UserTaskModel> _tasks=new ObservableCollection<UserTaskModel>();
        #endregion

        #region constructor
        public UserTaskUtil() { }
        #endregion

        #region properties
        public ObservableCollection<UserTaskModel> Tasks
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
