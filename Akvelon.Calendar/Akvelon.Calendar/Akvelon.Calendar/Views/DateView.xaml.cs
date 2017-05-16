// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateView.xaml.cs" company="Akvelon">
//  Philipp Ranzhin 
// </copyright>
// <summary>
//   The date view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Views
{
    using Akvelon.Calendar.ViewModels;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// The date view.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DateView : CarouselPage
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DateView"/> class.
        /// </summary>
        public DateView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the view model.
        /// </summary>
        public ApplicationVm ViewModel => this.BindingContext as ApplicationVm;
    }
}