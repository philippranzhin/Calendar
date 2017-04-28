using System.Collections.ObjectModel;
using System.Linq;
using Akvelon.Calendar.Infrastrucure;
using Akvelon.Calendar.Infrastrucure.UserTasks;

namespace Akvelon.Calendar.ViewModels
{
    class HourVM : DateVM
    {
        public HourVM(DateInfo dateInfo, ReadOnlyObservableCollection<UserTask> _tasks) : base(dateInfo, _tasks)
        {
        }
        protected override ReadOnlyObservableCollection<UserTask> Tasks
        {
            get
            {
                ObservableCollection<UserTask> result = new ObservableCollection<UserTask>(_tasks.Where(task =>
                    task.TaskDate.Year == _date.Date.Year &&
                    task.TaskDate.Month == _date.Date.Month &&
                    task.TaskDate.Day == _date.Date.Day &&
                    task.TaskDate.Hour == _date.Date.Hour));

                return new ReadOnlyObservableCollection<UserTask>(result);
            }
        }
    }
}
