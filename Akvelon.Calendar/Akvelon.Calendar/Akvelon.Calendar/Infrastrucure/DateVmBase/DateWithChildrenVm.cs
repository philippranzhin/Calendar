// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateWithChildrenVm.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The date with children view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Infrastrucure.DateVmBase
{
    using System.Collections.ObjectModel;

    using Akvelon.Calendar.Models;

    /// <summary>
    ///     The date with children view model. Extens the base class, adding in it the child collection of DateVm, provides interface to filling the child collection.
    /// </summary>
    public abstract class DateWithChildrenVm : DateVm
    {
        /// <summary>
        ///     The children.
        /// </summary>
        private readonly ObservableCollection<DateVm> children = new ObservableCollection<DateVm>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DateWithChildrenVm"/> class.
        /// </summary>
        /// <param name="dateInfo">
        /// The date info.
        /// </param>
        /// <param name="factory">
        /// The factory.
        /// </param>
        /// <param name="tasks">
        /// The tasks.
        /// </param>
        protected DateWithChildrenVm(
            DateInfoModel dateInfo,
            IDateVmFactory factory,
            ReadOnlyObservableCollection<UserTaskModel> tasks)
            : base(dateInfo, factory, tasks)
        {
        }

        /// <summary>
        ///     Gets the children.
        /// </summary>
        public ReadOnlyObservableCollection<DateVm> Children
        {
            get
            {
                if (this.children.Count == 0)
                {
                    this.ChildrenFilling();
                }

                return new ReadOnlyObservableCollection<DateVm>(this.children);
            }
        }

        /// <summary>
        ///     The children filling.
        /// </summary>
        protected abstract void ChildrenFilling();

        /// <summary>
        /// The register child.
        /// </summary>
        /// <param name="childDate">
        /// The child date.
        /// </param>
        protected virtual void RegisterChild(DateInfoModel childDate)
        {
            DateVm child = this.Factory.Create(childDate, this.Factory, this.Tasks);
            child.NewVmNeeded += this.OnNewWmNeeded;
            child.TaskAdded += (sender, task) =>
                {
                    this.OnTaskAdded(this, task);
                    this.OnTaskAdded(sender, task);
                };
            child.TaskRemoved += (sender, task) =>
                {
                    this.OnTaskRemoved(this, task);
                    this.OnTaskRemoved(sender, task);
                };
            this.children.Add(child);
            this.OnPropertyChanged("Children");
        }
    }
}