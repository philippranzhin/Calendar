using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Akvelon.Calendar.Infrastrucure;
using Akvelon.Calendar.Models;


namespace Akvelon.Calendar.ViewModels
{
    public class WeekVM : DateWithChildrenVM
    {
        #region constructors
        public WeekVM(DateInfoModel dateInfo, DateVMUtil dateVmUtil, ReadOnlyObservableCollection<UserTaskModel> tasks) : base(dateInfo, dateVmUtil, tasks)
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
                    task.TaskDate >= _date.Date.GetFirstDateOfWeek() &&
                    task.TaskDate <= _date.Date.GetLastDateOfWeek()));

                return new ReadOnlyObservableCollection<UserTaskModel>(result);
            }
        }

        public override string Name
        {
            get
            {
                string result = string.Empty;
                result += Children.First().Date.Date.ToString("dd MMM", CultureInfo.CurrentCulture);
                result += " - ";
                result += Children.Last().Date.Date.ToString("dd MMM", CultureInfo.CurrentCulture);
                return result;
            }
        }

        public string DayRow
        {
            get
            {
                string Row = "";
                Children.ToList().ForEach(day => Row+=$"{day.Date.Date.Day}\t");
                return Row;
            }
        }

        protected override DateInfoModel NextDate => new DateInfoModel(_date.Date.AddDays(DateTimeExtensions.WEEKSIZE), DateInfoType.Week);

        protected override DateInfoModel PreviousDate => new DateInfoModel(_date.Date.AddDays(-DateTimeExtensions.WEEKSIZE), DateInfoType.Week);
        #endregion

        #region methods     
        protected override void ChidrenFilling()
        {
            DateTime currentDate = Date.Date.GetFirstDateOfWeek();

            RegisterChild(new DateInfoModel(currentDate, DateInfoType.Day));
            currentDate = currentDate.AddDays(1);
            while (!currentDate.IsFirst())
            {
                RegisterChild(new DateInfoModel(currentDate, DateInfoType.Day));
                currentDate = currentDate.AddDays(1);
            }
        }
        #endregion
    }
}
