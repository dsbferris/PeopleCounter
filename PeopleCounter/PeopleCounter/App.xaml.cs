using Xamarin.Essentials;
using Xamarin.Forms;

namespace PeopleCounter
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			DeviceDisplay.KeepScreenOn = Preferences.Get("KeepDisplayOn", true);
			//TODO Change back to MainPage after implementation is done.
			MainPage = new NavigationPage(new PeopleCounter.Views.CounterPage());
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
