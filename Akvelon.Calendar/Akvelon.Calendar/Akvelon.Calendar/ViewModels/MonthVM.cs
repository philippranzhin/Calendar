using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Akvelon.Calendar.Infrastrucure;
using Akvelon.Calendar.Models;

namespace Akvelon.Calendar.ViewModels
{
    public class MonthVM : DateWithChildrenVM
    {
        #region constructors
        public MonthVM(DateInfoModel dateInfo, DateVMUtil dateVmUtil, ReadOnlyObservableCollection<UserTaskModel> tasks) : base(dateInfo, dateVmUtil, tasks)
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

        public override string Name => Date.Date.ToString("MMMM yyyy", CultureInfo.CurrentCulture);

        protected override DateInfoModel NextDate => new DateInfoModel(_date.Date.AddMonths(+1), DateInfoType.Month);

        protected override DateInfoModel PreviousDate => new DateInfoModel(_date.Date.AddMonths(-1), DateInfoType.Month);
        #endregion

        #region methods    
        protected override void ChidrenFilling()
        {
            DateTime currentDate = new DateTime(Date.Date.Year, Date.Date.Month, 1);
            RegisterChild(new DateInfoModel(currentDate, DateInfoType.Week));
            currentDate = currentDate.AddDays(1);

            while (!(currentDate.Month != Date.Date.Month && currentDate.IsFirst()))
            {
                if (currentDate.IsFirst())
                {
                    RegisterChild(new DateInfoModel(currentDate, DateInfoType.Week));
                }
                currentDate = currentDate.AddDays(1);
            }
        }
        #endregion
    }
}
