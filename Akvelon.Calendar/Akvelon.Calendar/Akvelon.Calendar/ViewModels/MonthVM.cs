using System.Collections.ObjectModel;
using System.Linq;
using Akvelon.Calendar.Infrastrucure;
using Akvelon.Calendar.Infrastrucure.UserTasks;

namespace Akvelon.Calendar.ViewModels
{
    class MonthVM : DateVM
    {
        #region constructors
        public MonthVM(DateInfo dateInfo, ReadOnlyObservableCollection<UserTask> tasks) : base(dateInfo, tasks)
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
                    task.TaskDate.Month == _date.Date.Month));

                return new ReadOnlyObservableCollection<UserTask>(result);
            }
        }
        #endregion

        #region methods
        public override DateVM GetNext()
        {
            return new MonthVM(new DateInfo(_date.Date.AddMonths(1), Enums.DateInfoType.Month), _tasks);
        }

        public override DateVM GetPrevious()
        {
            return new MonthVM(new DateInfo(_date.Date.AddMonths(-1), Enums.DateInfoType.Month), _tasks);
        }
        #endregion        
    }
}
