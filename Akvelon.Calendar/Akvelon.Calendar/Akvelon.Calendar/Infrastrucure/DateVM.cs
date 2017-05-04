using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Akvelon.Calendar.Models;
using Xamarin.Forms;

namespace Akvelon.Calendar.Infrastrucure
{
    public abstract class DateVM : IDateVM
    {
        #region fields
        protected readonly DateVMUtil _dateVmUtil;
        protected readonly DateInfoModel _date;
        protected readonly ReadOnlyObservableCollection<UserTaskModel> _tasks;
        #endregion

        #region constructors        
        protected DateVM(DateInfoModel dateInfo, DateVMUtil dateVmUtil, ReadOnlyObservableCollection<UserTaskModel> tasks)
        {
            _date = dateInfo;
            _tasks = tasks;
            _dateVmUtil = dateVmUtil;
            UpdateTasks();
        }
        #endregion

        #region properties
        public  abstract ReadOnlyObservableCollection<UserTaskModel> Tasks { get; }
        
        public DateInfoModel Date => _date;

        public bool IsCurrentDate=>Date.Compare(DateTime.Now);

        public abstract string Name { get;}

        protected abstract DateInfoModel NextDate { get; }

        protected abstract DateInfoModel PreviousDate { get; }
        #endregion

        #region methods
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnNewWMNeeded(IDateVM sender,DateVM newDateVM)
        {
            NewVMNeeded?.Invoke(sender, newDateVM);
        }

        protected virtual void OnTaskAdded(IUserTaskChanged sender, UserTaskModel task)
        {
            TaskAdded?.Invoke(sender,task);
        }

        protected virtual void OnTaskRemoved(IUserTaskChanged sender, UserTaskModel task)
        {
            TaskRemoved?.Invoke(sender, task);
        }

        public virtual DateVM GetNext()
        {
            return _dateVmUtil.GetOrCreate(NextDate);
        }

        public virtual DateVM GetPrevious()
        {
            return _dateVmUtil.GetOrCreate(PreviousDate);
        }

        public virtual void UpdateTasks()
        {
         OnPropertyChanged("Tasks");
        }
        #endregion

        #region commands
        public Command NextViewCommand
        {
            get
            {
                return new Command((sender) =>
                {                
                    OnNewWMNeeded(this,sender as DateVM);
                });
            }
        }

        public Command AddTaskCommand
        {
            get
            {
                return new Command(() =>
                {
                    TaskAdded?.Invoke(this, new UserTaskModel(Date.Date));
                });
            }
        }
        #endregion

        #region events
        public event PropertyChangedEventHandler PropertyChanged;
        public event TaskHandler TaskRemoved;
        public event TaskHandler TaskAdded;       
        public event DateVMHandler NewVMNeeded;
        #endregion
    }
}
