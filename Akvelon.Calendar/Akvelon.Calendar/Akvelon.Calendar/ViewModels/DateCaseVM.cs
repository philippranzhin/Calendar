using System.Collections.ObjectModel;
using System.Linq;
using Akvelon.Calendar.Infrastrucure;
using Akvelon.Calendar.Infrastrucure.UserTasks;

namespace Akvelon.Calendar.ViewModels
{
    public class DateCaseVM:MVVMBase
    {
        #region fields
        private const uint OLD_DATES_COUNT = 50;
        private DateVM _currentDateVM;
        private readonly UserTaskMediator _taskMedidator;
        private ObservableCollection<DateVM> _dateVMCollection;
        #endregion

        #region constructors
        public DateCaseVM(DateInfo currentDate, UserTaskMediator _userTaskMediator)
        {
            _taskMedidator = _userTaskMediator;
            CurrentDateVM = DateVMFactory.Create(currentDate, _taskMedidator.UserTasks);
            _dateVMCollection = new ObservableCollection<DateVM>();

            AddDateVM(CurrentDateVM.GetPrevious());
            AddDateVM(CurrentDateVM);
            AddDateVM(CurrentDateVM.GetNext());

            GenerateDates();
        }
        #endregion

        #region properties
        public DateVM CurrentDateVM
        {
            get { return _currentDateVM; }
            set
            {
                _currentDateVM = value;
                OnPropertyChanged("CurrentDateVM");

                if (DateVMCollection != null && DateVMCollection.Last() == CurrentDateVM)
                    DateVMCollection.Add(DateVMCollection.Last().GetNext());

                if (DateVMCollection != null && DateVMCollection.First() == CurrentDateVM)
                {
                    GenerateDates();
                }
            }
        }

        public ObservableCollection<DateVM> DateVMCollection => _dateVMCollection;
        #endregion

        #region methods
        private void GenerateDates()
        {
            if (DateVMCollection == null || DateVMCollection.Count == 0)
                return;

            for (int i = 0; i < OLD_DATES_COUNT; i++)
            {
                AddDateVM(DateVMCollection.First().GetPrevious());
                DateVMCollection.Move(DateVMCollection.Count - 1, 0);
            }
        }

        private void AddDateVM(DateVM dateVM)
        {
            DateVMCollection.Add(dateVM);
            _taskMedidator.AddClient(dateVM);
            dateVM.NewVMNeeded += OnNewWMNeeded;
        }

        private void RemoveDateVM(DateVM dateVM)
        {
            DateVMCollection.Remove(dateVM);
            _taskMedidator.RemoveClient(dateVM);
            dateVM.NewVMNeeded -= OnNewWMNeeded;
        }

        protected virtual void OnNewWMNeeded(IDateVM sender,DateInfo newDate)
        {
            NewVMNeeded?.Invoke(sender, newDate);
        }
        #endregion

        #region events
        public event DateVMHandler NewVMNeeded;
        #endregion
    }
}
