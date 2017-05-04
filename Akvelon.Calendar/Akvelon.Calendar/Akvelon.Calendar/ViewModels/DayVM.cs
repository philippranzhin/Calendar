using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Akvelon.Calendar.Infrastrucure;
using Akvelon.Calendar.Models;

namespace Akvelon.Calendar.ViewModels
{
    public class DayVM:DateWithChildrenVM
    {
        #region constructors
        public DayVM(DateInfoModel dateInfo, DateVMUtil dateVmUtil, ReadOnlyObservableCollection<UserTaskModel> tasks) : base(dateInfo, dateVmUtil, tasks)
        {
        }
        #endregion

        #region properties
        public override ReadOnlyObservableCollection<UserTaskModel> Tasks
        {
            get
            {
                ObservableCollection<UserTaskModel> result = new ObservableCollection<UserTaskModel>(_tasks.Where(task =>
                    task.TaskDate.Year == _date.Date.Year &&
                    task.TaskDate.Month == _date.Date.Month &&
                    task.TaskDate.Day == _date.Date.Day));

                return new ReadOnlyObservableCollection<UserTaskModel>(result);
            }
        }

        public override string Name => Date.Date.ToString("dddd MMM yy", CultureInfo.CurrentCulture);

        protected override DateInfoModel NextDate => new DateInfoModel(_date.Date.AddDays(+1), DateInfoType.Day);

        protected override DateInfoModel PreviousDate => new DateInfoModel(_date.Date.AddDays(-1), DateInfoType.Day);
        #endregion

        #region methods
        protected override void ChidrenFilling()
        {
            DateTime currentDate = new DateTime(Date.Date.Year,Date.Date.Month,Date.Date.Day,1,0,0);
            for (int i = 1; i <= DateTimeExtensions.HOURS_IN_DAY; i++)
            {
                RegisterChild(new DateInfoModel(currentDate,DateInfoType.Hour));
                currentDate=currentDate.AddHours(1);
            }
        }
        #endregion
    }
}
