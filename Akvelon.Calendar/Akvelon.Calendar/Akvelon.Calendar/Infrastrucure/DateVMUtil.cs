using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Akvelon.Calendar.Models;
using Akvelon.Calendar.ViewModels;

namespace Akvelon.Calendar.Infrastrucure
{
    public class DateVMUtil
    {
        #region fields
        private ReadOnlyObservableCollection<UserTaskModel> _tasks;
        private List<DateVM> _dateVMCollection=new List<DateVM>();
        #endregion

        #region constructors
        public DateVMUtil(ReadOnlyObservableCollection<UserTaskModel> tasks)
        {
            _tasks = tasks;
        }
        #endregion

        #region methods
        public DateVM GetOrCreate(DateInfoModel dateInfo)
        {
            DateVM result;

            result = _dateVMCollection.FirstOrDefault(dateVM => dateInfo.Compare(dateVM.Date));

            if (result != null)
                return result;

            switch (dateInfo.DateType)
            {
                case DateInfoType.Year:
                {
                    result = new YearVM(dateInfo, this, _tasks);
                    break;
                }
                case DateInfoType.Month:
                {
                    result = new MonthVM(dateInfo, this, _tasks);
                    break;
                }
                case DateInfoType.Week:
                {
                    result = new WeekVM(dateInfo, this, _tasks);
                    break;
                }
                case DateInfoType.Day:
                {
                    result = new DayVM(dateInfo, this, _tasks);
                    break;
                }
                case DateInfoType.Hour:
                {
                    result = new HourVM(dateInfo, this, _tasks);
                    break;
                }

                default:
                {
                   return null;
                }
            }

            _dateVMCollection.Add(result);
            return result;
        }
        #endregion
    }
}
