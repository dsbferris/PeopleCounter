using PeopleCounter.ViewModels;
using PeopleCounter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace PeopleCounter.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CounterPage : ContentPage
	{
		private CounterVM cvm;

		public CounterPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (!DesignMode.IsDesignModeEnabled)
			{
				cvm = new CounterVM();
				BindingContext = cvm;
			}
		}

		private void Plus()
		{
			try
			{
				Vibration.Vibrate(duration: (int)Models.Settings.Strenght);
			}
			catch (Exception)
			{
			}
			cvm.Increment();
			Number.TextColor = Color.Green;
			if (Models.Settings.PlaySound)
			{
				var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
				player.Load("Click1.wav");
				player.Play();
			}

		}

		private void Minus()
		{
			try
			{
				Vibration.Vibrate((int)Models.Settings.Strenght);
			}
			catch (Exception)
			{
			}
			cvm.Decrement();
			Number.TextColor = Color.Red;
			if (Models.Settings.PlaySound)
			{
				var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
				player.Load("Click2.wav");
				player.Play();
			}
		}


		private void Button_Clicked(object sender, EventArgs e)
		{
			var btn = sender as Button;
			if (btn.Text == "+")
			{
				Plus();
			}
			else if (btn.Text == "-")
			{
				Minus();
			}
		}

		private async void Edit_Clicked(object sender, EventArgs e)
		{
			var s = await DisplayPromptAsync("Custom number", "Enter custom number", placeholder: cvm.Counter.Current.ToString(), keyboard: Keyboard.Numeric);
			if (!String.IsNullOrEmpty(s))
			{
				cvm.Edit(s);
			}

		}

		private async void Settings_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SettingsPage());
		}

		private async void Reset_Clicked(object sender, EventArgs e)
		{
			if (await DisplayAlert("Reset?", "Sure you want to reset counter", "Yes", "No"))
			{
				cvm.Reset();
				Number.TextColor = Color.Black;
			}
		}
	}
}