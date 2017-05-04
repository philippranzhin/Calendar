using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Akvelon.Calendar.Infrastrucure;
using Akvelon.Calendar.Models;

namespace Akvelon.Calendar.ViewModels
{
    class HourVM:DateVM
    {
        #region constructors
        public HourVM(DateInfoModel dateInfo, DateVMUtil dateVmUtil, ReadOnlyObservableCollection<UserTaskModel> tasks) : base(dateInfo, dateVmUtil, tasks)
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
                    task.TaskDate.Day == _date.Date.Day &&
                    task.TaskDate.Hour==_date.Date.Hour));

                return new ReadOnlyObservableCollection<UserTaskModel>(result);
            }
        }
        public override string Name => Date.Date.ToString("h tt", CultureInfo.CurrentCulture);

        protected override DateInfoModel NextDate => new DateInfoModel(_date.Date.AddHours(+1), DateInfoType.Hour);

        protected override DateInfoModel PreviousDate => new DateInfoModel(_date.Date.AddHours(-1), DateInfoType.Hour);
        #endregion
    }
}
