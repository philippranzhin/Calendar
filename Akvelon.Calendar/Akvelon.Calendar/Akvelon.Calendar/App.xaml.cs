// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The application entry point
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar
{
    using Akvelon.Calendar.Models;
    using Akvelon.Calendar.Models.Enums;
    using Akvelon.Calendar.ViewModels;
    using Akvelon.Calendar.Views;

    using Xamarin.Forms;

    /// <summary>
    ///     The app.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="App" /> class.
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            ApplicationModel model = new ApplicationModel { Name = "Calendar" };
            ApplicationVm viewModel = new ApplicationVm(model, DateInfoType.Year);
            ApplicationView view = new ApplicationView { BindingContext = viewModel };

            this.MainPage = view;
        }

        /// <summary>
        ///     The on resume.
        /// </summary>
        protected override void OnResume()
        {
        }

        /// <summary>
        ///     The on sleep.
        /// </summary>
        protected override void OnSleep()
        { 
        }

        /// <summary>
        ///     The on start.
        /// </summary>
        protected override void OnStart()
        {
        }
    }
}