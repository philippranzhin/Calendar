using Akvelon.Calendar.Models;
using Akvelon.Calendar.ViewModels;
using Akvelon.Calendar.Views;
using Xamarin.Forms;

namespace Akvelon.Calendar
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
      
            ApplicationModel model=new ApplicationModel() {Name = "Calendar"};
            ApplicationVM viewModel=new ApplicationVM(model);
		    ApplicationView view = new ApplicationView();
		    view.BindingContext = viewModel;

            MainPage = view;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
