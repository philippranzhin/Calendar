// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddTaskView.xaml.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   Defines the AddTaskView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Views
{
    using Akvelon.Calendar.ViewModels;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// The add task view.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTaskView : ContentView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddTaskView"/> class.
        /// </summary>
        public AddTaskView()
        {
            this.InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

    }

}