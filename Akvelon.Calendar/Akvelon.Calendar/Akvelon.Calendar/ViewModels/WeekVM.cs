using System.Collections.ObjectModel;
using System.Linq;
using Akvelon.Calendar.Infrastrucure;
using Akvelon.Calendar.Infrastrucure.UserTasks;


namespace Akvelon.Calendar.ViewModels
{
    class WeekVM : DateVM
    {
        #region constructors
        public WeekVM(DateInfo dateInfo, ReadOnlyObservableCollection<UserTask> tasks) : base(dateInfo, tasks)
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
                    task.TaskDate >= _date.Date.GetFirstDateOfWeek() &&
                    task.TaskDate <= _date.Date.GetLastDateOfWeek()));

                return new ReadOnlyObservableCollection<UserTask>(result);
            }
        }
        #endregion

        #region methods
        public override DateVM GetNext()
        {
            return new WeekVM(new DateInfo(_date.Date.AddDays(DateTimeExtensions.WEEKSIZE), Enums.DateInfoType.Week), _tasks);
        }

        public override DateVM GetPrevious()
        {
            return new WeekVM(new DateInfo(_date.Date.AddDays(-DateTimeExtensions.WEEKSIZE), Enums.DateInfoType.Week), _tasks);
        }
        #endregion        
    }
}
