using System.Collections.ObjectModel;
using System.Linq;
using Akvelon.Calendar.Infrastrucure;
using Akvelon.Calendar.Infrastrucure.UserTasks;


namespace Akvelon.Calendar.ViewModels
{
    class WeekVM : DateVM
    {
        public WeekVM(DateInfo dateInfo, ReadOnlyObservableCollection<UserTask> _tasks) : base(dateInfo, _tasks)
        {
        }

        protected override ReadOnlyObservableCollection<UserTask> Tasks
        {
            get
            {           
                ObservableCollection<UserTask> result = new ObservableCollection<UserTask>(_tasks.Where(task =>
                    task.TaskDate.Year == _date.Date.Year &&
                    task.TaskDate.Month == _date.Date.Month &&
                    task.TaskDate>=_date.Date.GetFirstDateOfWeek() &&
                    task.TaskDate<= _date.Date.GetLastDateOfWeek()));

                return new ReadOnlyObservableCollection<UserTask>(result);
            }
        }
    }
}
