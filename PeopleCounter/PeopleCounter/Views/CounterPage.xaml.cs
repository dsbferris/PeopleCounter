using PeopleCounter.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace PeopleCounter.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CounterPage : ContentPage
	{

		public CounterPage()
		{
			InitializeComponent();
		}


		private async void Edit_Clicked(object sender, EventArgs e)
		{
			return;
			int current = (BindingContext as Counter).Current;
			var s = await DisplayPromptAsync("Custom number", "Enter custom number", placeholder: current.ToString(), keyboard: Keyboard.Numeric);
			if (!String.IsNullOrEmpty(s)) return;
				//cvm.Edit(s);
		}

		private async void Settings_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SettingsPage());
		}

		private async void Reset_Clicked(object sender, EventArgs e)
		{
			return;
			if (await DisplayAlert("Reset?", "Sure you want to reset counter", "Yes", "No"))
			{
				//cvm.Reset();
			}
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			if (Settings.Strenght > 0)
				Vibration.Vibrate(duration: (int)Settings.Strenght);
			if (Settings.PlaySound)
			{
				var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
				player.Load("Click1.wav");
				player.Play();
			}
		}
	}
}