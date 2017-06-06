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
    public partial class DateView : TabbedPage
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DateView"/> class.
        /// </summary>
        public DateView()
        {
            this.InitializeComponent();
            this.PropertyChanged += async (sender, args) =>
                {
                    if (args.PropertyName == "ItemsSource")
                    {
                        this.CurrentPage.Opacity = .1;
                        await this.CurrentPage.FadeTo(1, 260);
                    }              
                };    
        }

        /// <summary>
        /// Gets the view model.
        /// </summary>
        public ApplicationVm ViewModel => this.BindingContext as ApplicationVm;
    }
}