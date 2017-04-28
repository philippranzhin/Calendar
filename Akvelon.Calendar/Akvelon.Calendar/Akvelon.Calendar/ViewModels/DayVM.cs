using System.Collections.ObjectModel;
using System.Linq;
using Akvelon.Calendar.Infrastrucure;
using Akvelon.Calendar.Infrastrucure.UserTasks;

namespace Akvelon.Calendar.ViewModels
{
    class DayVM:DateVM
    {                
        #region constructors
        public DayVM(DateInfo dateInfo, ReadOnlyObservableCollection<UserTask> tasks) : base(dateInfo, tasks)
        {
        }
        #endregion

        #region properties
        protected override ReadOnlyObservableCollection<UserTask> Tasks
        {
            get
            {
                ObservableCollection<UserTask> result = new ObservableCollection<UserTask>(_tasks.Where(task =>
                    task.TaskDate.Year == _date.Date.Year &&
                    task.TaskDate.Month == _date.Date.Month &&
                    task.TaskDate.Day == _date.Date.Day));

                return new ReadOnlyObservableCollection<UserTask>(result);
            }
        }
        #endregion

        #region methods
        public override DateVM GetNext()
        {
            return new DayVM(new DateInfo(_date.Date.AddDays(1), Enums.DateInfoType.Day), _tasks);
        }

        public override DateVM GetPrevious()
        {
            return new DayVM(new DateInfo(_date.Date.AddDays(-1), Enums.DateInfoType.Day), _tasks);
        }
        #endregion        
    }
}
