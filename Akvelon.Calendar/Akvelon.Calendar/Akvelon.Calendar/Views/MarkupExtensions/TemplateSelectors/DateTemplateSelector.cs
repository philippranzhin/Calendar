// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTemplateSelector.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The date template selector.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Views.MarkupExtensions.TemplateSelectors
{
    using Akvelon.Calendar.ViewModels;

    using Xamarin.Forms;

    /// <summary>
    ///     The date template selector. Provides ability to select the actual Data Template in markup
    /// </summary>
    internal class DateTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        ///     Gets or sets the day template.
        /// </summary>
        public DataTemplate DayTemplate { get; set; }

        /// <summary>
        ///     Gets or sets the month template.
        /// </summary>
        public DataTemplate MonthTemplate { get; set; }

        /// <summary>
        ///     Gets or sets the week template.
        /// </summary>
        public DataTemplate WeekTemplate { get; set; }

        /// <summary>
        ///     Gets or sets the year template.
        /// </summary>
        public DataTemplate YearTemplate { get; set; }

        /// <summary>
        /// The on select template.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <returns>
        /// The <see cref="DataTemplate"/>.
        /// </returns>
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is YearVm)
            {
                return this.YearTemplate;
            }

            if (item is MonthVm)
            {
                return this.MonthTemplate;
            }

            if (item is WeekVm)
            {
                return this.WeekTemplate;
            }

            if (item is DayVm)
            {
                return this.DayTemplate;
            }

            return null;
        }
    }
}