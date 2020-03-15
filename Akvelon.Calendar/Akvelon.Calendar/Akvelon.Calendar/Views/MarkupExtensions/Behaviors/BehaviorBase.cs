// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BehaviorBase.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The behavior base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Views.MarkupExtensions.Behaviors
{
    using System;

    using Xamarin.Forms;

    /// <summary>
    /// The behavior base.
    /// </summary>
    /// <typeparam name="T">
    /// Object
    /// </typeparam>
    public class BehaviorBase<T> : Behavior<T>
        where T : BindableObject
    {
        /// <summary>
        ///     Gets the associated object.
        /// </summary>
        public T AssociatedObject { get; private set; }

        /// <summary>
        /// The on binding context changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="arguments">
        /// The arguments.
        /// </param>
        public void OnBindingContextChanged(object sender, EventArgs arguments)
        {
            this.OnBindingContextChanged();
        }

        /// <summary>
        /// The on attached to.
        /// </summary>
        /// <param name="bindable">
        /// The object.
        /// </param>
        protected override void OnAttachedTo(T bindable)
        {
            base.OnAttachedTo(bindable);
            this.AssociatedObject = bindable;

            if (bindable.BindingContext != null)
            {
                this.BindingContext = bindable.BindingContext;
            }

            bindable.BindingContextChanged += this.OnBindingContextChanged;
        }

        /// <summary>
        ///     The on binding context changed.
        /// </summary>
        protected override void OnBindingContextChanged()
        {
            this.OnBindingContextChanged();
            this.BindingContext = this.AssociatedObject.BindingContext;
        }

        /// <summary>
        /// The on detaching from.
        /// </summary>
        /// <param name="bindable">
        /// The binding.
        /// </param>
        protected override void OnDetachingFrom(T bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.BindingContextChanged -= this.OnBindingContextChanged;
            this.AssociatedObject = null;
        }
    }
}