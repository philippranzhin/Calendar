using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Akvelon.Calendar.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ApplicationView : TabbedPage
    {
		public ApplicationView ()
		{
			InitializeComponent ();
		}
	}
}