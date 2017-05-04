using System.Collections.ObjectModel;
using Akvelon.Calendar.Models;

namespace Akvelon.Calendar.Infrastrucure
{
    public abstract class DateWithChildrenVM:DateVM
    {
        #region fields
        private ObservableCollection<DateVM> _children=new ObservableCollection<DateVM>();
        #endregion

        #region constructors
        public DateWithChildrenVM(DateInfoModel dateInfo, DateVMUtil dateVmUtil, ReadOnlyObservableCollection<UserTaskModel> tasks) : base(dateInfo, dateVmUtil, tasks)
        {
        }
        #endregion

        #region properties

        public ReadOnlyObservableCollection<DateVM> Children
        {
            get
            {
                if(_children.Count==0)
                    ChidrenFilling();
                return new ReadOnlyObservableCollection<DateVM>(_children);
            }
        }

        #endregion

        #region methods
        protected virtual void RegisterChild(DateInfoModel childDate)
        {
            DateVM child=_dateVmUtil.GetOrCreate(childDate);
            child.NewVMNeeded += OnNewWMNeeded;
            child.TaskAdded += (sender, task) =>
            {
                OnTaskAdded(this, task);
                OnTaskAdded(sender, task);
            };
            child.TaskRemoved += (sender, task) => 
            {
                OnTaskRemoved(this, task);
                OnTaskRemoved(sender, task);
            };
            _children.Add(child);
            OnPropertyChanged("Children");
        }

        protected abstract void ChidrenFilling();

        public virtual void UpdateTasks()
        {
            OnPropertyChanged("Tasks");
        }
        #endregion   
    }
}
