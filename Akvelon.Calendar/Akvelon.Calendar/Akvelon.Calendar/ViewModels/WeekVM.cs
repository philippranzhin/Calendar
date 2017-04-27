using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Akvelon.Calendar.Infrastrucure;
using Akvelon.Calendar.Infrastrucure.UserTasks;

namespace Akvelon.Calendar.ViewModels
{
    class WeekVM : DateVM
    {
        public WeekVM(DateInfo dateInfo, ObservableCollection<UserTask> _tasks) : base(dateInfo, _tasks)
        {
        }

        //TODO
        protected override ObservableCollection<UserTask> Tasks
        {
            get { return null; }
        }
    }
}
