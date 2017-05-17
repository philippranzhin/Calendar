// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MvvmBase.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The mvvm base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Infrastrucure.DateVmBase
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    ///     The mvvm base. Describes the objects, that can be a view model.
    /// </summary>
    public abstract class MvvmBase : INotifyPropertyChanged
    {
        /// <summary>
        ///     The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}