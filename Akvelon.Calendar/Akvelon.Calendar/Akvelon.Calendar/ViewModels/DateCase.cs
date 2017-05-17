// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateCase.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The date line.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using Akvelon.Calendar.Infrastrucure.DateVmBase;
    using Akvelon.Calendar.Infrastrucure.UserTasks;
    using Akvelon.Calendar.Models;

    using Xamarin.Forms;

    /// <summary>
    /// The date case. Describes objects that always contain three DateVm, and ensure that they have a common type
    /// </summary>
    public class DateCase : IDateVm
    {
        /// <summary>
        /// Count of views to display
        /// </summary>
        private const uint ViewsNumber = 3;

        /// <summary>
        /// The children.
        /// </summary>
        private ObservableCollection<DateVm> children;

        /// <summary>
        /// The selected child.
        /// </summary>
        private DateVm selectedChild;
       
        /// <summary>
        /// Initializes a new instance of the <see cref="DateCase"/> class.
        /// </summary>
        /// <param name="selectedChild">
        /// The selected child.
        /// </param>
        public DateCase(DateVm selectedChild)
        {
            this.Children = new ObservableCollection<DateVm> { selectedChild };
            this.SelectedChild = selectedChild;
        }

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The task added.
        /// </summary>
        public event TaskHandler TaskAdded;

        /// <summary>
        /// The task removed.
        /// </summary>
        public event TaskHandler TaskRemoved;

        /// <summary>
        /// The new view model needed.
        /// </summary>
        public event DateVmHandler NewVmNeeded;

        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        public ObservableCollection<DateVm> Children
        {
            get
            {
                return this.children;
            }

            set
            {
                this.children = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the selected child.
        /// </summary>
        public DateVm SelectedChild
        {
            get
            {
                return this.selectedChild;
            }

            set
            {
                if (this.selectedChild != null)
                {
                    this.selectedChild.NewVmNeeded -= this.OnNewWmNeeded;
                    this.selectedChild.TaskAdded -= this.OnTaskAdded;
                }

                value.NewVmNeeded += this.OnNewWmNeeded;
                value.TaskAdded += this.TaskAdded;

                this.selectedChild = value;
                this.OnPropertyChanged();             

                this.ProvideTransition();
            }
        }

        /// <summary>
        /// The name.
        /// </summary>
        public string Name => this.SelectedChild.Name;

        /// <summary>
        /// The update tasks.
        /// </summary>
        public void UpdateTasks()
        {
            foreach (DateVm dateVm in this.Children)
            {
                dateVm.UpdateTasks();
            }
        }

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// The on new view model needed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="newDateVm">
        /// The new date view model.
        /// </param>
        protected virtual void OnNewWmNeeded(IDateVm sender, DateVm newDateVm)
        {
            this.NewVmNeeded?.Invoke(sender, newDateVm);
        }

        /// <summary>
        /// The on task added.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="task">
        /// The task.
        /// </param>
        protected virtual void OnTaskAdded(IUserTaskChanged sender, UserTaskModel task)
        {
            this.TaskAdded?.Invoke(sender, task);
        }

        /// <summary>
        /// Creates (if need) and adds to collection previous and next Date view models. Removes unused view models.
        /// </summary>
        private void ProvideTransition()
        {
            if (this.Children.Count == 1)
            {
                this.Children.Insert(0, this.SelectedChild.GetPrevious());
                this.Children.Add(this.SelectedChild.GetNext());
            }

            if (this.Children.Count == ViewsNumber && this.Children.Last() == this.SelectedChild)
            {
                Device.BeginInvokeOnMainThread(
                    () =>
                        {
                            this.Children.Remove(this.Children.First());
                            this.Children.Add(this.SelectedChild.GetNext());
                        });
            }

            if (this.Children.Count == ViewsNumber && this.Children.First() == this.SelectedChild)
            {
                Device.BeginInvokeOnMainThread(
                    () =>
                        {
                            this.Children.Remove(this.Children.Last());
                            this.Children.Insert(0, this.SelectedChild.GetPrevious());
                        });
            }
        }     
    }
}
