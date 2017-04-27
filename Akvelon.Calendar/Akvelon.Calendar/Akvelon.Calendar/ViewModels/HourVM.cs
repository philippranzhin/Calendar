using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Akvelon.Calendar.Infrastrucure;
using Akvelon.Calendar.Infrastrucure.UserTasks;

namespace Akvelon.Calendar.ViewModels
{
    class HourVM : DateVM
    {
        public HourVM(DateInfo dateInfo, ObservableCollection<UserTask> _tasks) : base(dateInfo, _tasks)
        {
        }
        protected override ObservableCollection<UserTask> Tasks
        {
            get
            {
                return new ObservableCollection<UserTask>(_tasks.Where(task => task.TaskDate.Year == _date.Date.Year &&
                                                                               task.TaskDate.Month == _date.Date.Month &&
                                                                               task.TaskDate.Day == _date.Date.Day &&
                                                                               task.TaskDate.Hour == _date.Date.Hour));
            }
        }
    }
}
