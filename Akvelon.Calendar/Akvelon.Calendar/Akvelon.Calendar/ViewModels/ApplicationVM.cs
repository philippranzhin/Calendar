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
        private readonly UserTaskMediator _taskMedidator;
        private DateCaseVM _currentDateCase;
        private ObservableCollection<DateCaseVM> _dateCases=new ObservableCollection<DateCaseVM>();
        #endregion

        #region constructors
        public ApplicationVM(ApplicationModel model, Enums.DateInfoType dateType = Enums.DateInfoType.Year)
        {
            _taskMedidator=new UserTaskMediator();
            _model = model;
            DateInfo currentDate = new DateInfo(DateTime.Now, dateType);
                   
           AddDateCase(new DateCaseVM(currentDate,_taskMedidator));

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

        public DateCaseVM CurrentDateCase
        {
            get
            {
                return _currentDateCase;                 
            }
            set
            {
                _currentDateCase = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<DateCaseVM> DateCases
        {
            get { return _dateCases; }
            private set
            {
                _dateCases = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region methods
        private void AddDateCase(DateCaseVM dateCase)
        {
            DateCases.Add(dateCase);
            dateCase.NewVMNeeded += (sender, args) =>
            {
                AddDateCase(new DateCaseVM(args,_taskMedidator));
            };
            CurrentDateCase = dateCase;
        }
        #endregion
    }
}
