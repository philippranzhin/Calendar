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
    using Akvelon.Calendar.Models.Interfaces;
    using Akvelon.Calendar.ViewModels;
    using Akvelon.Calendar.Views;

    using Xamarin.Forms;

    /// <summary>
    ///     The app.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public App(IApplicationModel model)
        {
            this.InitializeComponent();

            ApplicationVm viewModel = new ApplicationVm(model);

            NavigationPage navigationPage = new NavigationPage();

            this.MainPage = navigationPage;

            MasterDetailPage master = new MasterDetailPage()
            {
                Master = new SettingsView() { BindingContext = viewModel },
                Detail = new DateView() { BindingContext = viewModel }
            };

            master.SetBinding(Page.TitleProperty, "Title");
            master.BindingContext = master.Detail;

            navigationPage.PushAsync(master);
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