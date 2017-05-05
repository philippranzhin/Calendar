// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationView.xaml.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The application view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    ///     The application view.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApplicationView : TabbedPage
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationView" /> class.
        /// </summary>
        public ApplicationView()
        {
            this.InitializeComponent();
        }
    }
}