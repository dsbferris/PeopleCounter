using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PeopleCounter
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			if(!DesignMode.IsDesignModeEnabled) DeviceDisplay.KeepScreenOn = Preferences.Get("KeepDisplayOn", true);
			MainPage = new Views.MasterDetail.MainPage();
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
