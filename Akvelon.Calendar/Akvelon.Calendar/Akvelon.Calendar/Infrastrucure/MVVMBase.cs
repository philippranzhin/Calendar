﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Akvelon.Calendar.Infrastrucure
{
    public abstract class MVVMBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
