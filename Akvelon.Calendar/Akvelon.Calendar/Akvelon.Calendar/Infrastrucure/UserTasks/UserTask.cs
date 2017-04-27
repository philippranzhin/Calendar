using System;

namespace Akvelon.Calendar.Infrastrucure.UserTasks
{
    public class UserTask : MVVMBase
    {
        #region fields

        #endregion

        #region constructors
        public UserTask(DateTime date)
        {
            TaskDate = date;
        }
        #endregion

        #region properties
        public DateTime TaskDate { get; }
        #endregion
    }
}
