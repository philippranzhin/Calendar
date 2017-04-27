using System;
using System.Collections.Generic;
using System.Text;
using Akvelon.Calendar.Models;

namespace Akvelon.Calendar.ViewModels
{
    public class ApplicationVM:ViewModelBase
    {
        #region fields

        private ApplicationModel _model;        

        #endregion

        #region constructor

        public ApplicationVM(ApplicationModel model)
        {
            _model = model;
        }

        #endregion

        #region Properties

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
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
