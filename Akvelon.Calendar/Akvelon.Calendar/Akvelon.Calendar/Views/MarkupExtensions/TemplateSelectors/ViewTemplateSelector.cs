// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewTemplateSelector.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The view template selector.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Views.MarkupExtensions.TemplateSelectors
{
    using Akvelon.Calendar.Infrastrucure.DateVmBase;
    using Akvelon.Calendar.ViewModels;

    using Xamarin.Forms;

    /// <summary>
    /// The view template selector.
    /// </summary>
    public class ViewTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Gets or sets the date template.
        /// </summary>
        public DataTemplate DateTemplate { get; set; }

        /// <summary>
        /// Gets or sets the add task template.
        /// </summary>
        public DataTemplate AddTaskTemplate { get; set; }

        public ControlTemplate Template { get; set; }

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
            if (item is DateVm)
            {                
                return this.DateTemplate;
            }

            if (item is AddTaskVm)
            {
                return this.AddTaskTemplate;
            }

            return null;
        }
    }
}
