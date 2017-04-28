using System.Collections.ObjectModel;
using Akvelon.Calendar.Infrastrucure.UserTasks;
using Akvelon.Calendar.ViewModels;

namespace Akvelon.Calendar.Infrastrucure
{
    public class DateVMFactory
    {
        public static DateVM Create(DateInfo dateInfo, ReadOnlyObservableCollection<UserTask> tasks)
        {
            switch (dateInfo.DateType)
            {
                case Enums.DateInfoType.Year:
                {
                    return new YearVM(dateInfo, tasks);
                }
                case Enums.DateInfoType.Month:
                {
                    return new MonthVM(dateInfo, tasks);
                }
                case Enums.DateInfoType.Week:
                {
                    return new WeekVM(dateInfo, tasks);
                }
                case Enums.DateInfoType.Day:
                {
                    return new DayVM(dateInfo, tasks);
                }
                default:
                {
                    return null;
                }
            }
        }
    }
}
