// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NavigationView.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The navigation view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Akvelon.Calendar.Infrastrucure.DateVmBase;

    using Xamarin.Forms;

    /// <summary>
    /// The navigation view.
    /// </summary>
    public class NavigationView : NavigationPage
    {
        /// <summary>
        /// The current.
        /// </summary>
        private IDateVm current;

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationView"/> class.
        /// </summary>
        /// <param name="pages">
        /// The pages.
        /// </param>
        public NavigationView(IEnumerable<Page> pages)
        {
            this.Pages = pages;
            this.PushAsync(this.Pages.First());
        }

        /// <summary>
        /// Gets the pages.
        /// </summary>
        public IEnumerable<Page> Pages { get; }

        /// <summary>
        /// Gets or sets the current.
        /// </summary>
        public IDateVm Current
        {
            get
            {
                return this.current;
            }

            set
            {
                this.current = value;

                try
                {
                    this.PushAsync(this.Pages.First(page => page.BindingContext == this.Current));
                }
                catch
                {
                    // ignored
                }
            }
        }
    }
}
