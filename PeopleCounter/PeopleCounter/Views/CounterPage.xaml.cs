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
			cvm = new CounterVM();
			BindingContext = cvm;
			InitializeComponent();
		}


		private async void Edit_Clicked(object sender, EventArgs e)
		{
			var s = await DisplayPromptAsync("Custom number", "Enter custom number", placeholder: cvm.Counter.Current.ToString(), keyboard: Keyboard.Numeric);
			if (!String.IsNullOrEmpty(s))
				cvm.Edit(s);
		}

		private async void Settings_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new SettingsPage());
		}

		private async void Reset_Clicked(object sender, EventArgs e)
		{
			if (await DisplayAlert("Reset?", "Sure you want to reset counter", "Yes", "No"))
			{
				cvm.Reset();
			}
		}
	}
}