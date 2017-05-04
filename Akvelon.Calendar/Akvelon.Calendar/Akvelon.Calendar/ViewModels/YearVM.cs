using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Akvelon.Calendar.Infrastrucure;
using Akvelon.Calendar.Models;

namespace Akvelon.Calendar.ViewModels
{
    public class YearVM : DateWithChildrenVM
    {
        #region constructors
        public YearVM(DateInfoModel dateInfo, DateVMUtil dateVmUtil, ReadOnlyObservableCollection<UserTaskModel> tasks) : base(dateInfo, dateVmUtil, tasks)
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
                    task.TaskDate.Month == _date.Date.Month));

                return new ReadOnlyObservableCollection<UserTaskModel>(result);
            }
        }

        public override string Name => Date.Date.ToString("yyyy",CultureInfo.CurrentCulture);

        protected override DateInfoModel NextDate=>new DateInfoModel(_date.Date.AddYears(+1), DateInfoType.Year);

        protected override DateInfoModel PreviousDate => new DateInfoModel(_date.Date.AddYears(-1), DateInfoType.Year);
        #endregion

        #region methods    
        protected override void ChidrenFilling()
        {
            for (int i = 1; i <= DateTimeExtensions.MONTHS_IN_YEAR; i++)
            {
                DateTime currentDate = new DateTime(Date.Date.Year, i, 1);
                RegisterChild(new DateInfoModel(currentDate, DateInfoType.Month));
            }
        }
        #endregion
    }
}
