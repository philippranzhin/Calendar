using System.Collections.ObjectModel;
using System.Linq;
using Akvelon.Calendar.Infrastrucure;
using Akvelon.Calendar.Infrastrucure.UserTasks;

namespace Akvelon.Calendar.ViewModels
{
    public class YearVM : DateVM
    {
        #region constructors
        public YearVM(DateInfo dateInfo, ReadOnlyObservableCollection<UserTask> tasks) : base(dateInfo, tasks)
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
            return new YearVM(new DateInfo(_date.Date.AddYears(+1), Enums.DateInfoType.Year), _tasks);
        }

        public override DateVM GetPrevious()
        {
            return new YearVM(new DateInfo(_date.Date.AddYears(-1), Enums.DateInfoType.Year), _tasks);
        }
        #endregion
    }
}
