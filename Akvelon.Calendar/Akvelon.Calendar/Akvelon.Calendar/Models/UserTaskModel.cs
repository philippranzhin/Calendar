using System;
using Akvelon.Calendar.Infrastrucure;

namespace Akvelon.Calendar.Models
{
    public class UserTaskModel : MVVMBase
    {
        #region fields

        #endregion

        #region constructors
        public UserTaskModel(DateTime date)
        {
            TaskDate = date;
        }
        #endregion

        #region properties
        public DateTime TaskDate { get; }
        #endregion
    }
}
