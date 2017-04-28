using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Akvelon.Calendar.Infrastrucure.UserTasks;

namespace Akvelon.Calendar.Infrastrucure
{
    public abstract class DateVM : IDateVM
    {
        #region fields
        protected readonly DateInfo _date;
        protected readonly ReadOnlyObservableCollection<UserTask> _tasks;
        #endregion

        #region constructors        
        protected DateVM(DateInfo dateInfo, ReadOnlyObservableCollection<UserTask> tasks)
        {
            _date = dateInfo;
            _tasks = tasks;
            UpdateTasks();
        }
        #endregion

        #region properties
        protected  abstract ReadOnlyObservableCollection<UserTask> Tasks { get; }
        #endregion

        #region methods
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnNewWMNeeded(DateInfo newDate)
        {
            NewVMNeeded?.Invoke(this,newDate);
        }

        public void UpdateTasks()
        {
         OnPropertyChanged("Tasks");
        }
        #endregion

        #region events
        public event PropertyChangedEventHandler PropertyChanged;
        public event TaskHandler TaskRemoved;
        public event TaskHandler TaskAdded;       
        public event DateVMHandler NewVMNeeded;
        #endregion
    }
}
