using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PeopleCounter
{
	public partial class App : Application
	{

		public static string FolderPath { get; private set; }

		public App()
		{
			InitializeComponent();
			DeviceDisplay.KeepScreenOn = Preferences.Get("KeepDisplayOn", true);
			FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
			//TODO Change back to MainPage after implementation is done.
			MainPage = new NavigationPage(new PeopleCounter.Views.MainPage());
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
