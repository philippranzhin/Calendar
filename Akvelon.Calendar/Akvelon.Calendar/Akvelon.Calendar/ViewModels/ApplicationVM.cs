using System;
using System.Collections.ObjectModel;
using Akvelon.Calendar.Infrastrucure;
using Akvelon.Calendar.Infrastrucure.UserTasks;
using Akvelon.Calendar.Models;

namespace Akvelon.Calendar.ViewModels
{
    public class ApplicationVM : MVVMBase
    {
        #region fields
        private ApplicationModel _model;
        private ObservableCollection<DateVM> _dateViewModels;
        private DateVM _currentDateVM;
        private readonly UserTaskMediator _taskMedidator;
        #endregion

        #region constructors
        public ApplicationVM()
        {
            DateInfo currentDate = new DateInfo(DateTime.Now, DateInfoType.Year);
            CurrentDateVM = DateVMFactory.Create(currentDate, _taskMedidator.UserTasks);
        }

        public ApplicationVM(ApplicationModel model)
        {
            _model = model;
        }
        #endregion

        #region properties
        public ApplicationModel Model
        {
            get { return _model; }
            private set
            {
                _model = value;
                OnPropertyChanged("Model");
            }
        }

        public string Name
        {
            get { return Model.Name; }
            private set
            {
                Model.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public ObservableCollection<DateVM> DateViewModels
        {
            get { return _dateViewModels; }
            private set
            {
                _dateViewModels = value;
                OnPropertyChanged("DateViewModels");
            }
        }

        public DateVM CurrentDateVM
        {
            get { return _currentDateVM; }
            set
            {
                _currentDateVM = value;
                OnPropertyChanged("CurrentDateVM");

                if(!DateViewModels.Contains(_currentDateVM))
                    DateViewModels.Add(_currentDateVM);
            }
        }
        #endregion

        #region methods

        #endregion
    }
}
